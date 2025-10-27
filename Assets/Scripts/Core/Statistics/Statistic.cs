using UnityEngine;
using System.Collections.Generic;
using Core.Enum;
using Core.Statistics;

[System.Serializable]
public class Statistic
{
    [field: SerializeField] public StatType StatType { get; private set; }
    
    //Value
    [field: SerializeField] public int CurrentStatValue { get; private set; }
    [field: SerializeField] public UpgradeFormulaData UpgradeStatFormula { get; private set; }
    
    //Price
    [field: SerializeField] public int CurrentPrice { get; private set; }
    [field: SerializeField] public UpgradeFormulaData UpgradePriceFormula { get; private set; }
    
    [field: SerializeField] public int UpgradeCount { get; private set; }
    
    public void Upgrade()
    {
        CurrentStatValue = UpgradeStatFormula.CalculateValue(CurrentStatValue,UpgradeCount);
        CurrentPrice = UpgradePriceFormula.CalculateValue(CurrentPrice,UpgradeCount);
        UpgradeCount++;
    }
}
