using System.Collections.Generic;
using Core.Enum;
using UnityEngine;

[CreateAssetMenu(fileName = "DuckData", menuName = "Scriptable Objects/DuckData")]
public class DuckData : ScriptableObject
{
    [field: SerializeField]
    public DuckType DuckType { get; private set; }
    
    //Base values
    [field: SerializeField]
    public int cost { get; private set; }
    public Statistic[] stats;

    public Dictionary<StatType, Statistic> StatByType { get; private set; }
    
    [field: SerializeField]
    public Duck duck_prefab { get; private set; }
    
    private void OnEnable()
    {
        StatByType = new Dictionary<StatType, Statistic>();
        foreach (var s in stats)
            StatByType[s.StatType] = s;
    }
    
    public bool TryGetStat(StatType type, out Statistic stat)
        => StatByType.TryGetValue(type, out stat);
}
