using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem: MonoBehaviour, IAffordable<Satistique>
{

    //list of all category of ducks
    private DuckData[] ducks;
    private List<Satistique> stats;
  
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        //retrieve all data of ducks
        ducks = GameController.GameDatabase.Ducks;

        stats = new List<Satistique>();
        foreach (var duck in ducks)
        {
            stats.Add(new Satistique("damage",10, duck.damage,1,1));
            stats.Add(new Satistique("coingain",10, duck.coingain,1,1));
            stats.Add(new Satistique("speed",10, (int)duck.speed,1,1));
        }
    }
    
    public bool Buy(ref int coin, Satistique stat)
    {
        if (coin > stat.price)
        {
            coin -= stat.price;
            stat.Upgrade();
            return true;
        }

        return false;
    }

}
