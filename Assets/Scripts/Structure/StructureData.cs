using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Structures/ StructudeData")]
public class StructureData : ScriptableObject
{
    public string name;

    public int cost;

    public int pollution;

    public float pollutionTime;

    public int revenue;

    public float revenueTime;
}
