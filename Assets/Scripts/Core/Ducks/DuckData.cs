using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DuckData", menuName = "Scriptable Objects/DuckData")]
public class DuckData : ScriptableObject
{
    [field: SerializeField]
    public int cost { get; private set; }
    [field: SerializeField]
    public int damage { get; private set; }
    [field: SerializeField]
    public int coingain { get; private set; }
    [field: SerializeField]
    public float speed { get; private set; }
    
    [field: SerializeField]
    public Satistique[] stats { get; private set; }
   
    
    [field: SerializeField]
    public Duck_ duck_prefab { get; private set; }

    public int GetDammage()
    {
        foreach (var stat in stats)
        {
            if (stat.name == "dammage")
            {
                return stat.value;
            }
        }
        return -1;
    }
    
    public int GetSpeed()
    {
        foreach (var stat in stats)
        {
            if (stat.name == "speed")
            {
                return stat.value;
            }
        }
        return -1;
    }
    
    public int GetCoinGain()
    {
        foreach (var stat in stats)
        {
            if (stat.name == "coingain")
            {
                return stat.value;
            }
        }
        return -1;
    }
}
