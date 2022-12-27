using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "ScriptableObject/GroundData")]
public class GroundDataSO : EnvironmentDataSO
{
    [field: SerializeField] public int WalkSpeed { get; set; }
}