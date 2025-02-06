using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem: MonoBehaviour, IAffordable<Satistique>
{

    //list of all category of ducks
    private DuckData[] ducks;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        //retrieve all data of ducks
        ducks = GameController.GameDatabase.Ducks;
        
        foreach (var duck in ducks)
        {
            duck.stats = new Satistique[3];
            duck.stats[0] = (new Satistique("damage",10, duck.damage,1,1));
            duck.stats[1] = (new Satistique("coingain",10, duck.coingain,1,1));
            duck.stats[2] = (new Satistique("speed",10, (int)duck.speed,1,1));
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
