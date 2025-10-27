using System;
using System.Collections.Generic;
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
    
    [field:SerializeField]
    private UI_Statistique[] stats_text;

    private Button Lock_1;
    [SerializeField] private Bubble bubble;
    
    
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
        GameManager.Instance.OnStatUp += UpdateStatUI;
        GameManager.Instance.OnBubbleLifeChange += UpdateBubbleUI;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnUpdatePlayerCoin -= UpdateCoinUI;
        GameManager.Instance.OnStatUp -= UpdateStatUI;
        GameManager.Instance.OnBubbleLifeChange -= UpdateBubbleUI;
    }


    private void UpdateCoinUI(int coin)
    {
        uIcoin.Sync(coin);
    }
    
    private void UpdateBubbleUI(int life)
    {
        uIBubbleLife.Sync(life);
    }
    
    private void UpdateStatUI(DuckType duckType,StatType statType, int value, int cost)
    {
        foreach (var statistic in stats_text)
        {
            if (statistic.DoesItMatch(duckType, statType))
            {
                statistic.Sync(value,cost);
            }
        }
    }

    public void BuyDuck(int duckTypeIndex)
    {
        DuckType duckType = (DuckType)duckTypeIndex;
        GameManager.Instance.DuckManager.BuyDuck(duckType);
    }

    public void BuyStat(UI_Statistique uiStatistique)
    {
       GameManager.Instance.DuckManager.BuyStatUpgrade(uiStatistique.StatType, uiStatistique.DuckType);
    }
    
    public void BuyLock(Locker locker)
    {
        GameManager.Instance.LockManager.BuyLocker(locker);
    }
    
}
