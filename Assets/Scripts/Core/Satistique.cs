using UnityEngine;
using System.Collections.Generic;

public class Satistique
{
    public string name { get; private set; }
    public int price { get; private set; }
    public int priceUp { get; private set; }
    public int value { get; private set; }
    public int valueUp { get; private set; }

    public Satistique(string statname, int statprice, int statvalue, int statpriceup, int statvelueup)
    {
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
