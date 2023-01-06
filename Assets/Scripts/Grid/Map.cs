using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WorldGrid
{
    public class Map
    {
        public Cell[,] Cells { get; }

        public List<Coord> ChangedGroundsCoords { get; set; } = new() { new(1, 1), new(2, 2) };
        public List<Coord> ChangedObjectsCoords { get; set; } = new() { new(2, 2) };
        public List<Coord> ChangedItemsCoords { get; set; } = new() { new(3, 3) };

        public int Width { get; }
        public int Height { get; }

        public BiomeDataSO BiomeData { get; private set; }

        public SaveObject Save
        {
            get
            {
                SerializableDictionary<Coord, SerializableList<CellDataSO>> cells = new();
                foreach (Coord coord in ChangedGroundsCoords)
                {
                    AddToCells(coord, GetTileAt(coord).GroundData);
                }
                foreach (Coord coord in ChangedObjectsCoords)
                {
                    AddToCells(coord, GetTileAt(coord).ObjectData);
                }
                foreach (Coord coord in ChangedItemsCoords)
                {
                    AddToCells(coord, GetTileAt(coord).ItemData);
                }

                return new()
                {
                    width = Width,
                    height = Height,
                    biomeData = BiomeData,
                    cells = cells
                };

                void AddToCells(Coord coord, CellDataSO cellData)
                {
                    if (cells.ContainsKey(coord))
                    {
                        cells[coord].Add(cellData);
                    }
                    else
                    {
                        cells.Add(coord, new() { cellData });
                    }
                }
            }
        }

        public Map(BiomeDataSO biomeData, int width = 100, int height = 100, Cell[,] cells = null)
        {
            BiomeData = biomeData;

            Width = width;
            Height = height;

            Cells = new Cell[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (cells != null)
                    {
                        Cells[x, y] = cells[x, y];
                    }
                    else
                    {
                        Cells[x, y] = new Cell();
                    }                    
                }
            }

            Debug.Log($"World created with {width * height} tiles.");
        }

        public Cell GetTileAt(Coord coord)
        {
            if (coord.x > Width || coord.x < 0 || coord.y > Height || coord.y < 0)
            {
                Debug.LogError($"{coord} is out of range.");
                return null;
            }
            return Cells[coord.x, coord.y];
        }

        public Cell GetTileAt(int x, int y)
            => GetTileAt(new Coord(x, y));

        [Serializable]
        public struct SaveObject : ISaveable
        {
            public int width;
            public int height;
            public BiomeDataSO biomeData;

            public SerializableDictionary<Coord, SerializableList<CellDataSO>> cells;

            public bool IsLoading { get; set; }

            public void Load()
            {
                IsLoading = true;

                var cells = JsonHelper.ToArray2D(this.cells, width, height); 
                var island = MapController.Instance.Map;

                foreach (var coord in island.ChangedGroundsCoords)
                {

                }

                IsLoading = false;
            }
        }
    }
}