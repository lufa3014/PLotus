using Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGrid : MonoBehaviour
{
    public static MapGrid Instance { get; private set; }

    [SerializeField] private Transform gridDebugObjectPrefab;
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private int cellSize;


    private GridSystem<GridObject> gridSystem;

    private void Awake()
    {
        if (Instance is not null)
        {
            Debug.LogError("There's more than one MapGrid! " + Instance.name);
            Destroy(gameObject);
            return;
        }
        Instance = this;

        gridSystem = new GridSystem<GridObject>(width, height, cellSize,
            (GridSystem<GridObject> g, Coord coord) => new GridObject(g, coord));
        gridSystem.CreateDebugObjects(gridDebugObjectPrefab);
    }

    private void Start()
    {
    }
}
