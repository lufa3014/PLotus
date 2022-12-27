using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "ScriptableObject/Ground/TerrainData")]
public class TerrainDataSO : GroundDataSO
{
    [field: SerializeField] public int PlantGrowthSpeed { get; set; } = 0;
    [field: SerializeField] public int DealsDamage { get; set; } = 0;
}