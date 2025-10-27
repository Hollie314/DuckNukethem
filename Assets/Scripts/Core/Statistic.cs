using UnityEngine;
using System.Collections.Generic;
using Core.Enum;

[System.Serializable]
public class Statistic
{
    [field: SerializeField] public StatType StatType { get; private set; }
    [field: SerializeField] public int CurrentPrice { get; private set; }
    [field: SerializeField] public float CurrentStatValue { get; private set; }
    [field: SerializeField] public float UpgradeStatAndPriceMultiplier { get; private set; }
    
    public void Upgrade()
    {
        CurrentPrice += (int)(CurrentPrice*UpgradeStatAndPriceMultiplier);
        CurrentStatValue += CurrentStatValue*UpgradeStatAndPriceMultiplier;
    }
}
