using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Grid
{
    public class GridObject
    {
        private GridSystem<GridObject> gridSystem;
        private Coord coord;

        public override string ToString()
            => coord.ToString();


        public GridObject(GridSystem<GridObject> gridSystem, Coord coord)
        {
            this.gridSystem = gridSystem;
            this.coord = coord;
        }
    }
}