using System;
using Core.Enum;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //for singleton behavior
    public static GameManager Instance { get; private set; }
    
    //Player money
    public int playerCoins = 2;
    
    //event for UI 
    public event Action<int> OnUpdatePlayerCoin;
    public event Action<DuckType,StatType,int, int> OnStatUp;
    public event Action<int> OnBubbleLifeChange; 
    public event Action OnMoneySpentCoin;
    public event Action OnNotEnoughMoney;
    
    //All Managers
    [field: SerializeField]
    public LockManager LockManager { get; private set; }
    [field: SerializeField]
    public StatManager StatManager { get; private set; }
    [field: SerializeField]
    public DuckManager DuckManager { get; private set; }

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

    public void Start()
    {
        OnUpdatePlayerCoin?.Invoke(playerCoins);
    }


    public void GainCoin(int coingain)
    {
        playerCoins += coingain;
        OnUpdatePlayerCoin?.Invoke(playerCoins);
    }
    
    public bool TrySpendCoins(int cost)
    {
        if (playerCoins >= cost)
        {
            playerCoins -= cost;
            OnUpdatePlayerCoin?.Invoke(playerCoins);
            OnMoneySpentCoin?.Invoke();
            return true;
        }
        OnNotEnoughMoney?.Invoke();
        return false;
    }

    public void UpdateStat(DuckType duckType, StatType statType, int statValue, int statCost)
    {
        OnStatUp?.Invoke(duckType, statType, statValue, statCost);
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
