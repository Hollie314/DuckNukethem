using System;
using System.Collections.Generic;
using Core.Ducks.Skin;
using Core.Enum;
using Core.UI;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
    //for singleton behavior
    public static UIManager Instance { get; private set; }
    
    
    [SerializeField]
    private UI_Text uIcoin;
    [SerializeField]
    private UI_Text uIBubbleLife;
    [SerializeField]
    private UI_Text uiAutomatePrice;
    
    [field:SerializeField]
    private UI_Statistic[] stats_text;
    
    
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
    
    // for singleton Ensures it's created automatically if accessed before existing
    public static UIManager GetInstance()
    {
        if (Instance == null)
        {
            GameObject managerObject = new GameObject("UIManager");
            Instance = managerObject.AddComponent<UIManager>();
            DontDestroyOnLoad(managerObject);
        }
        return Instance;
    }
    
    
    /*
     * subscribe to questionManagers events
     */
    private void OnEnable()
    {
        GameManager.Instance.OnUpdatePlayerCoin += UpdateCoinUI;
        GameManager.Instance.OnBubbleLifeChange += UpdateBubbleUI;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnUpdatePlayerCoin -= UpdateCoinUI;
        GameManager.Instance.OnBubbleLifeChange -= UpdateBubbleUI;
    }
    
    //initialize the UI info 
    private void Start()
    {
        uiAutomatePrice.Sync(GameManager.Instance.AutomateManager.unLockPrice);
        uIcoin.Sync(GameManager.Instance.playerCoins);
        uIBubbleLife.Sync(GameManager.Instance.Bubble.CurrentHealthPoint);
        foreach (var uiStatistic in stats_text)
        {
            if (GameManager.Instance.DuckManager.TryGetDuckStat(uiStatistic.DuckType, uiStatistic.StatType, out Statistic stat))
            {
                uiStatistic.Sync((int)stat.CurrentStatValue, stat.CurrentPrice);
            }
        }
    }


    private void UpdateCoinUI(int coin)
    {
        uIcoin.Sync(coin);
    }
    
    private void UpdateBubbleUI(int life)
    {
        uIBubbleLife.Sync(life);
    }

    public void BuyDuck(int duckTypeIndex)
    {
        DuckType duckType = (DuckType)duckTypeIndex;
        GameManager.Instance.DuckManager.BuyDuck(duckType);
    }

    public void BuyStat(UI_Statistic uiStatistic)
    {
        if (GameManager.Instance.DuckManager.BuyStatUpgrade(uiStatistic.StatType, uiStatistic.DuckType, out int currentStatValue, out int currentStatPrice))
        {
            uiStatistic.Sync(currentStatValue,currentStatPrice);
        }
    }
    
    public void BuyLock(UI_Locker uiLocker)
    {
        GameManager.Instance.LockManager.BuyLocker(uiLocker);
    }

    public void BuyAutomation()
    {
        if (GameManager.Instance.AutomateManager.BuyAutomateUpgrade(out int price))
        {
            uiAutomatePrice.Sync(price);
        }
    }

    public void SelectSkin(DuckSkin duckSkin)
    {
        if(GameManager.Instance.SkinManager.SetSelectedSkin(duckSkin, out DuckSkin lastSelected))
        {
            lastSelected.UnSelect();
            duckSkin.Select();
        }
    }
    
}
