using UnityEngine;
using System.Collections.Generic;
using Core.Enum;

public class Statistique
{
    public int StatID { get; private set; }
    public StatType StatType { get; private set; }
    public int CurrentPrice { get; private set; }
    public float CurrentStatValue { get; private set; }
    public float UpgradeStatAndPriceMultiplier { get; private set; }

    public Statistique(int statID, int baseprice, float baseStatValue, StatType statType, float upgradeStatAndPriceMultiplier)
    {
        StatID = statID;
        CurrentPrice = baseprice;
        CurrentStatValue = baseStatValue;
        StatType = statType;
        UpgradeStatAndPriceMultiplier = upgradeStatAndPriceMultiplier;
    }
    public void Upgrade()
    {
        CurrentPrice += (int)(CurrentPrice*UpgradeStatAndPriceMultiplier);
        CurrentStatValue += CurrentStatValue*UpgradeStatAndPriceMultiplier;
    }
}
