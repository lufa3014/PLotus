using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/BiomeData")]
public class BiomeDataSO : ScriptableObject
{
    [field: SerializeField] public TerrainDataSO TerrainMain { get; set; }
    [field: SerializeField] public TerrainDataSO TerrainVariant1 { get; set; }
    [field: SerializeField] public TerrainDataSO TerrainVariant2 { get; set; }
}