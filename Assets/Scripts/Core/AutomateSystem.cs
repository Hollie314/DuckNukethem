using System;
using UnityEngine;

public class AutomateSystem : MonoBehaviour, IAffordable<int>
{
    private DuckManager _duckManager;
    private int lvl = 0;
    private Satistique automateStat;


    private void Start()
    {
        automateStat = new Satistique(0, "cd_spawn", 100, 2, 10, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Buy(ref int coin, int product)
    {
        if (coin < automateStat.price)
        {
            automateStat.Upgrade();
            return true;
        }
        return false;
    }
}
