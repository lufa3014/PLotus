using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Grid
{
    public class GridSystem<TGridObject>
    {
        private int width;
        private int height;
        private float cellSize;

        public TGridObject[,] cells;

        public GridSystem(int width, int height, float cellSize, Func<GridSystem<TGridObject>, Vector2Int, TGridObject> createGridObject)
        {
            this.width = width;
            this.height = height;
            this.cellSize = cellSize;

            cells = new TGridObject[width, height];

            for (int x = 0; x <  width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    //GridPosition gridPosition = new GridPosition(x, y);
                    cells[x, y] = createGridObject(this, new Vector2Int(x, y));
                }
            }
        }

        //public Vector3 GetWorldPosition(GridPosition gridPosition)
        //    => new Vector3(gridPosition.x, 0, gridPosition.z);

        //public GridPosition GetGridPosition(Vector3 worldPosition)
        //{ 
        //    return new GridPosition(worldPosition.x)
        //}

        public void CreateDebugObjects(Transform debugPrefabs)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Vector2Int gridPosition = new Vector2Int(x, y);

                    Transform debugTransform = GameObject.Instantiate(debugPrefabs, new Vector3(gridPosition.x, gridPosition.y, 0) * cellSize, Quaternion.identity);
                    GridDebugObject gridDebugObject = debugTransform.GetComponent<GridDebugObject>();
                    gridDebugObject.SetGridObject(cells[gridPosition.x, gridPosition.y]);
                }
            }
        }
    }
}