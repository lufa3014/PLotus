using UnityEngine;

namespace MyGrid
{
    public class Map
    {
        public Cell[,] Cells { get; }

        public int Width { get; }
        public int Height { get; }

        public BiomeDataSO BiomeData { get; private set; }

        public Map(BiomeDataSO biomeData, int width = 100, int height = 100)
        {
            BiomeData = biomeData;

            Width = width;
            Height = height;

            Cells = new Cell[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Cells[x, y] = new Cell();
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
    }
}