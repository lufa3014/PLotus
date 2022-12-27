using MyGrid;
using System;
using System.Drawing;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class MapController : MonoBehaviour
{
    public static MapController Instance { get; set; }

    [field: SerializeField] public BiomeDataSO BiomeData { get; private set; }
    [field: SerializeField] public Tilemap Ground { get; private set; }
    [field: SerializeField] public Tilemap Object { get; private set; }
    [field: SerializeField] public Tilemap Item { get; private set; }


    public float scale = .1f;

    public Map Map { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There should never be more than one world controller.");
        }
        Instance = this;

        Map = new Map(BiomeData, 325, 325);
    }

    private void Start()
    {
        float[,] noiseMap = new float[Map.Width, Map.Height];
        (float xOffset, float yOffset) = (UnityEngine.Random.Range(-10000f, 10000f), UnityEngine.Random.Range(-10000f, 10000f));
        for (int y = 0; y < Map.Height; y++)
        {
            for (int x = 0; x < Map.Width; x++)
            {
                float noiseValue = Mathf.PerlinNoise(x * scale + xOffset, y * scale + yOffset);
                noiseMap[x, y] = noiseValue;
            }
        }


        for (int x = 0; x < Map.Width; x++)
        {
            for (int y = 0; y < Map.Height; y++)
            {
                Cell cell = Map.GetTileAt(x, y);

                float noiseValue = noiseMap[x, y];

                if (noiseValue < .2f)
                {
                    cell.GroundData = BiomeData.TerrainVariant2;
                }
                else if (noiseValue < .4f)
                {
                    cell.GroundData = BiomeData.TerrainVariant1;
                }
                else
                {
                    cell.GroundData = BiomeData.TerrainMain;
                }

                Ground.SetTile(new Vector3Int(x, y), cell.GroundData.Visual);


                Coord coord = new Coord(x, y);
                cell.OnGroundDataChanged += (object sender, EventArgs e) =>
                {
                    ChangeGroundVisual(coord, (sender as Cell).GroundData.Visual);
                };

                cell.OnObjectDataChanged += (object sender, EventArgs e) =>
                {
                    ChangeObjectVisual(coord, (sender as Cell).ObjectData.Visual);
                };

                cell.OnItemDataChanged += (object sender, EventArgs e) =>
                {
                    ChangeItemVisual(coord, (sender as Cell).ItemData.Visual);
                };
            }
        }
    }

    public void ChangeGroundVisual(Coord coord, TileBase groundVisual)
    {
        Ground.SetTile(new Vector3Int(coord.x, coord.y), groundVisual);
    }

    public void ChangeObjectVisual(Coord coord, TileBase objectVisual)
    {
        Object.SetTile(new Vector3Int(coord.x, coord.y), objectVisual);
    }

    public void ChangeItemVisual(Coord coord, TileBase itemVisual)
    {
        Item.SetTile(new Vector3Int(coord.x, coord.y), itemVisual);
    }
}
