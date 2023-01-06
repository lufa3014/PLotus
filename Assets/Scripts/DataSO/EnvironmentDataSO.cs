using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class EnvironmentDataSO : CellDataSO, ITileVisual
{
    [field: SerializeField] public int Attractiveness { get; set; }
    [field: SerializeField] public bool CanCatchOnFire { get; set; }

    //======== ITileVisual ========
    [field: SerializeField] public TileBase Visual { get; set; }
}