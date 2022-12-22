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

        public GridSystem(int width, int height, float cellSize, Func<GridSystem<TGridObject>, Coord, TGridObject> createGridObject)
        {
            this.width = width;
            this.height = height;
            this.cellSize = cellSize;

            cells = new TGridObject[width, height];

            for (int x = 0; x <  width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Coord coord = new Coord(x, y);
                    cells[x, y] = createGridObject(this, coord);
                }
            }
        }

        public Vector3 GetWorldPosition(Coord coord)
            => new Vector3(coord.x, coord.y, 0) * cellSize;
        

        public void CreateDebugObjects(Transform debugPrefabs)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Coord coord = new Coord(x, y);

                    Transform debugTransform = GameObject.Instantiate(debugPrefabs, GetWorldPosition(coord), Quaternion.identity);
                    GridDebugObject gridDebugObject = debugTransform.GetComponent<GridDebugObject>();
                    gridDebugObject.SetGridObject(cells[coord.x, coord.y]);
                }
            }
        }
    }
}