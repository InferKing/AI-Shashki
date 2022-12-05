using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CellType
{
    White,
    Black,
    WhiteQueen,
    BlackQueen,
    Empty
}
public class Model
{
    public Cell[,] cells;
    public Model()
    {
        cells = new Cell[8, 8];
        CreateCells();
    }
    private void CreateCells()
    {
        for (int i = 1; i < cells.GetLength(0); i+= 2)
        {
            cells[0,i] = new Cell(CellType.Black, new Vector2Int(0, i));
            cells[2, i] = new Cell(CellType.Black, new Vector2Int(2, i));
            cells[6,i] = new Cell(CellType.White, new Vector2Int(6, i));
        }
        for (int i = 0; i < cells.GetLength(0); i+=2)
        {
            cells[1, i] = new Cell(CellType.Black, new Vector2Int(1, i));
            cells[5,i] = new Cell(CellType.White, new Vector2Int(5, i));
            cells[7, i] = new Cell(CellType.White, new Vector2Int(7, i));
        }
    }
    public bool HasMoveToKill(Cell cell)
    {
        return true;
    }
    public void TryUpgradeCell(Cell cell)
    {
        if (cell.cellType is CellType.White && cell.pos.x == 0)
        {
            cell.cellType = CellType.WhiteQueen;
            cells[cell.pos.x, cell.pos.y] = cell;
        }
        else if (cell.cellType is CellType.Black && cell.pos.x == 7)
        {
            cell.cellType = CellType.BlackQueen;
            cells[cell.pos.x, cell.pos.y] = cell;
        }
    }

    public void GetListCellToMove(Cell curCell, ref List<string> outА) 
    {
        // рекурсия, возвращает все возможные пути вида a1->c3,c3->e5;
    }
}
public class Cell
{
    public CellType cellType = CellType.Empty;
    public Vector2Int pos;
    public Cell(CellType cellType, Vector2Int pos)
    {
        this.cellType = cellType;
        this.pos = pos;
    }
}

