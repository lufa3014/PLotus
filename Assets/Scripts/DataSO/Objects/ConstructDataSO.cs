using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Object/ConstructData")]
public class ConstructDataSO : ObjectDataSO, IConstructable
{
    [field: SerializeField] public int ConstructionTime { get; set; }
    [field: SerializeField] public int ConstructionCost { get; set; }
    [field: SerializeField] public int Health { get; set; }
}
