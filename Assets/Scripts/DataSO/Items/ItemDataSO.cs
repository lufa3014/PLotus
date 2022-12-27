using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "ScriptableObject/ItemData")]
public class ItemDataSO : ScriptableObject, ITileVisual
{
    [field: SerializeField] public bool IsStackable { get; set; }

    //======== ITileVisual ========
    [field: SerializeField] public TileBase Visual { get; set; }
}