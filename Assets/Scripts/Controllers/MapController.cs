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

                cell.OnGroundDataChanged += (object sender, EventArgs e) =>
                {
                    ChangeGroundVisual(x, y, (sender as Cell).GroundData.Visual);
                };

                cell.OnObjectDataChanged += (object sender, EventArgs e) =>
                {
                    ChangeObjectVisual(x, y, (sender as Cell).ObjectData.Visual);
                };

                cell.OnItemDataChanged += (object sender, EventArgs e) =>
                {
                    ChangeItemVisual(x, y, (sender as Cell).ItemData.Visual);
                };
            }
        }
    }

    public void ChangeGroundVisual(int x, int y, TileBase groundVisual)
    {
        Ground.SetTile(new Vector3Int(x, y), groundVisual);
    }

    public void ChangeObjectVisual(int x, int y, TileBase objectVisual)
    {
        Object.SetTile(new Vector3Int(x, y), objectVisual);
    }

    public void ChangeItemVisual(int x, int y, TileBase itemVisual)
    {
        Item.SetTile(new Vector3Int(x, y), itemVisual);
    }
}
