using UnityEngine;

public class Upgrade<T> : MonoBehaviour
{

    private string name;

    private int lvl;

    private int cost;

    private int costUp;

    private T value;

    private T valueUp;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void UpgradeStat()
    {
        //value += new T(valueUp);
    }
}
