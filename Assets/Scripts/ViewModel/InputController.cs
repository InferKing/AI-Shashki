using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputController : MonoBehaviour
{
    public static Action<EveryCell> OnCellSelected;
    public static Action<EveryCell> OnTurn;
    [SerializeField] private EveryCell[] _cells;
    private Model _model;
    private EveryCell _cell, _target;
    private void Start()
    {
        _model = new Model();
        StartCoroutine(InputCor());
    }
    private IEnumerator InputCor()
    {
        while (Application.isPlaying)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                yield return StartCoroutine(SetCell());
            }
            yield return null;
        }
    }
    private IEnumerator SetCell()
    {
        bool b = false;
        foreach (var cell in _cells)
        {
            if (cell.IsOverlap())
            {
                b = true;
                _cell = cell;
            }
        }
        if (!b) _cell = null;
        Vector2Int vect = _cell.GetIndex();
        Debug.Log(vect);
        //List<Cell> cells = _model.GetListCellToMove(_model.cells[vect.x,vect.y]);
        OnCellSelected?.Invoke(_cell);
        yield return null;
        // yield return StartCoroutine(ToCell());
    }
    private IEnumerator ToCell()
    {
        while (!Input.GetKeyDown(KeyCode.Mouse0))
        {
            yield return null;
        }
        foreach (var cell in _cells)
        {
            if (cell.IsOverlap())
            {
                _target = cell;
            }
        }
        // обновление модели
        OnTurn?.Invoke(_target);
    }
}
