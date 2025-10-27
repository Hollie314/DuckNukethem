using System;
using System.Collections.Generic;
using Core.Enum;
using UnityEngine;

public class StatManager: MonoBehaviour
{
    private int id=0;
    public List<Statistic> Statistiques { get; private set; }

    public void Awake()
    {
        Statistiques = new List<Statistic>();
    }

    public bool BuyDuck(ref int coin, int statID)
    {
       
        return false;
    }
    

    public void RemoveStat(Statistic stat)
    {
        Statistiques.Remove(stat);
    }

    public bool TryGetStat(int ID, out Statistic stat)
    {
        stat = null;
        return false;
    }
}
