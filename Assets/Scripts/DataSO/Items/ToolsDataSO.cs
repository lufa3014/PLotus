using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Item/ToolData")]
public class ToolsDataSO : ItemDataSO
{
    [field: SerializeField] public int DamageAmount { get; set; }
    [field: SerializeField] public int CraftingCost { get; set; }
    [field: SerializeField] public int Durabilty { get; set; }
}
