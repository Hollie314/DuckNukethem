using System;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //for singleton behavior
    public static GameManager Instance { get; private set; }
    
    //Player money
    private int playerCoins = 0;
    
    //event for UI 
    public event Action<int> OnUpdatePlayerCoin;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // trying to buy something from a manager
    public void Buy<T>(IAffordable<T> manager, T product)
    {
        if (manager.Buy(ref playerCoins, product))
        {
            OnUpdatePlayerCoin?.Invoke(playerCoins);
        }
        else
        {
            //not enough money sadge
        }
    }

    public void GainCoin(int coingain)
    {
        playerCoins += coingain;
        OnUpdatePlayerCoin?.Invoke(playerCoins);
    }
    
    // for singleton Ensures it's created automatically if accessed before existing
    public static GameManager GetInstance()
    {
        if (Instance == null)
        {
            GameObject managerObject = new GameObject("GameManager");
            Instance = managerObject.AddComponent<GameManager>();
            DontDestroyOnLoad(managerObject);
        }
        return Instance;
    }
}
