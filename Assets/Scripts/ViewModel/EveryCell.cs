using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EveryCell : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _collider;
    private string _name;
    private void Awake()
    {
        _name = GetFieldName();
    }
    public string GetFieldName()
    {
        _name = gameObject.name;
        if (_name.Contains(")"))
        {
            return $"{_name[0]}{int.Parse(_name[1].ToString()) + int.Parse(_name[_name.IndexOf(')') - 1].ToString())}";
        }
        return $"{_name[0]}{_name[1]}";
    }
    public bool IsOverlap() => _collider.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    public Vector2Int GetIndex()
    {
        Vector2Int vect = new Vector2Int();
        switch (_name[0])
        {
            case 'a':
                vect.y = 0;
                break;
            case 'b':
                vect.y = 1;
                break;
            case 'c':
                vect.y = 2;
                break;
            case 'd':
                vect.y = 3;
                break;
            case 'e':
                vect.y = 4;
                break;
            case 'f':
                vect.y = 5;
                break;
            case 'g':
                vect.y = 6;
                break;
            case 'h':
                vect.y = 7;
                break;
        }
        vect.x = 8 - int.Parse(_name[1].ToString());
        return vect;
    }
}
