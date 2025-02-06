using System.Collections.Generic;
using UnityEngine;

public class StatUpgrade: MonoBehaviour, IAffordable<Satistique>
{
    [field: SerializeField]
    public DuckData duck_type { get; private set; }
    [field: SerializeField]
    public int statIndex{ get; private set; }

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
