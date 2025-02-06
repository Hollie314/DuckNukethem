using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //for singleton behavior
    public static GameManager Instance { get; private set; }
    
    //Player money
    private int playerCoins = 2;
    
    //event for UI 
    public event Action<int> OnUpdatePlayerCoin;
    public event Action<int,int> OnStatUp;
    public event Action<int> OnBubbleLifeChange; 
    public event Action OnMoneySpentCoin;
    public event Action OnNotEnoughMoney;

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
        
        OnUpdatePlayerCoin?.Invoke(playerCoins);
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

    public void UpdateStat(int stat_id, int stat_value)
    {
        Debug.Log(stat_value);
        OnStatUp?.Invoke(stat_id, stat_value);
    }
    
    public void UpdateBubbleLife(int life)
    {
        OnBubbleLifeChange?.Invoke(life);
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
