using System.Collections.Generic;
using Core.Enum;
using UnityEngine;

[CreateAssetMenu(fileName = "DuckData", menuName = "Scriptable Objects/DuckData")]
public class DuckData : ScriptableObject
{
    [field: SerializeField]
    public DuckType DuckType { get; private set; }
    
    [field: SerializeField]
    public int cost { get; private set; }
    [field: SerializeField]
    public int damage { get; private set; }
    [field: SerializeField]
    public int coingain { get; private set; }
    [field: SerializeField]
    public float speed { get; private set; }
    
    [field: SerializeField]
    public float UpgradeStatAndPriceMultiplier { get; private set; }
    
    [field: SerializeField]
    public int BaseUpgradePrice { get; private set; }
    
    
    [field: SerializeField] public Statistique[] stats;
   
    
    [field: SerializeField]
    public Duck duck_prefab { get; private set; }

    public int GetDammage()
    {
        foreach (var stat in stats)
        {
            if (stat.StatType == StatType.Damage)
            {
                return (int)stat.CurrentStatValue;
            }
        }
        return -1;
    }
    
    public float GetSpeed()
    {
        foreach (var stat in stats)
        {
            if (stat.StatType == StatType.Speed)
            {
                return stat.CurrentStatValue;
            }
        }
        return -1;
    }
    
    public int GetCoinGain()
    {
        foreach (var stat in stats)
        {
            if (stat.StatType == StatType.Gain)
            {
                return (int)stat.CurrentStatValue;
            }
        }
        return -1;
    }
}
