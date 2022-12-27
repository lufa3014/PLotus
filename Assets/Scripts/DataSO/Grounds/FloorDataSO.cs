using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Ground/FloorData")]
public class FloorDataSO : GroundDataSO, IConstructable
{
    [field: SerializeField] public int DealsDamage { get; set; } = 0;

    //======== IConstructable ========
    [field: SerializeField] public int ConstructionTime { get; set; }
    [field: SerializeField] public int ConstructionCost { get; set; }
}