using UnityEngine;
using System.Collections.Generic;

public class Satistique
{
    public int id { get; private set; }
    public string name { get; private set; }
    public int price { get; private set; }
    public int priceUp { get; private set; }
    public int value { get; private set; }
    public int valueUp { get; private set; }

    public Satistique(int stat_id,string statname, int statprice, int statvalue, int statpriceup, int statvelueup)
    {
        id = stat_id;
        name = statname;
        price = statprice;
        value = statvalue;
        priceUp = statpriceup;
        valueUp = statvelueup;
    }
    public void Upgrade()
    {
        price += priceUp;
        value += valueUp;
    }
}
