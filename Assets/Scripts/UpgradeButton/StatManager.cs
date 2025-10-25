using System;
using System.Collections.Generic;
using Core.Enum;
using UnityEngine;

public class StatManager: MonoBehaviour, IAffordable<int>
{
    private int id=0;
    public List<Statistique> Statistiques { get; private set; }

    public void Awake()
    {
        Statistiques = new List<Statistique>();
    }

    public bool Buy(ref int coin, int statID)
    {
        if (GameManager.Instance.StatManager.TryGetStat(statID, out Statistique stat))
        {
            if (coin > (int)stat.CurrentPrice)
            {
                coin -= (int)stat.CurrentPrice;
                stat.Upgrade();
                GameManager.Instance.UpdateStat(stat.StatID, (int)stat.CurrentStatValue);
                return true;
            }
        }
        return false;
    }

    public Statistique AddStat(int baseUpgradePrice, float baseValue, StatType statType, float upgradeStatAndPriceMultiplier)
    {
        Statistique stat = new Statistique(id, baseUpgradePrice, baseValue, statType, upgradeStatAndPriceMultiplier);
        Statistiques.Add(stat);
        id++;
        return stat;
    }

    public void RemoveStat(Statistique stat)
    {
        Statistiques.Remove(stat);
    }

    public bool TryGetStat(int ID, out Statistique stat)
    {

        foreach (var statistique in Statistiques)
        {
            if (statistique.StatID == ID)
            {
                stat = statistique;
                return true;
            }
        }
        stat = null;
        return false;
    }
}
