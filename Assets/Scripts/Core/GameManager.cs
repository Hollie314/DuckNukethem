using System;
using Core.Ducks.Skin;
using Core.Enum;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //for singleton behavior
    public static GameManager Instance { get; private set; }
    
    //Player money
    public int playerCoins = 2;
    
    //event for UI/SFX
    public event Action<int> OnBubbleLifeChange; 
    public event Action<int> OnUpdatePlayerCoin;
    public event Action OnMoneySpentCoin;
    public event Action OnNotEnoughMoney;
    public event Action<int> OnBubbleExploded;
    
    //All Managers
    [field: SerializeField]
    public LockManager LockManager { get; private set; }
    [field: SerializeField]
    public DuckManager DuckManager { get; private set; }
    [field: SerializeField]
    public AutomateManager AutomateManager { get; private set; }
    [field: SerializeField]
    public SkinManager SkinManager { get; private set; }
    
    //The buble ref
    [field: SerializeField]
    public Bubble Bubble { get; private set; }

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
    
    public void UpdateBubbleLife(int life)
    {
        OnBubbleLifeChange?.Invoke(life);
    }
    
    public void UpdateBubbleExplode(int lvl)
    {
        OnBubbleExploded?.Invoke(lvl);
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
