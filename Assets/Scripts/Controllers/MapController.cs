using MyGrid;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapController : MonoBehaviour
{
    public static MapController Instance { get; set; }

    [field: SerializeField] public BiomeDataSO BiomeData { get; private set; }
    [field: SerializeField] public Tilemap Ground { get; private set; }
    [field: SerializeField] public Tilemap Object { get; private set; }
    [field: SerializeField] public Tilemap Item { get; private set; }


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
        for (int x = 0; x < Map.Width; x++)
        {
            for (int y = 0; y < Map.Height; y++)
            {
                Cell cell = Map.GetTileAt(x, y);

                switch (UnityEngine.Random.Range(0, 3))
                {
                    case 0: cell.GroundData = BiomeData.TerrainMain; break;
                    case 1: cell.GroundData = BiomeData.TerrainVariant1; break;
                    case 2: cell.GroundData = BiomeData.TerrainVariant2; break;
                    default: break;
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
