using Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject
{
    private GridSystem<GridObject> gridSystem;
    private Vector2Int gridPosition;

    public override string ToString()
        => $"({gridPosition.x}, {gridPosition.y})";


    public GridObject(GridSystem<GridObject> gridSystem, Vector2Int gridPosition)
    {
        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
    }
}
