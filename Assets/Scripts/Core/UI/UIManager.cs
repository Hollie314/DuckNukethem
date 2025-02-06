using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private UI_Text uIcoin;
    [SerializeField]
    private UI_Text uIBubbleLife;

    [field: SerializeField]
    private LockManager lockManager;
    [field: SerializeField]
    private StatUpgrade statManager;
    [field: SerializeField]
    private DuckManager duckManager;


    private Button Lock_1;

    [SerializeField] private Bubble bubble;
    /*
     * subscribe to questionManagers events
     */
    private void OnEnable()
    {
        GameManager.Instance.OnUpdatePlayerCoin += UpdateCoinUI;
        bubble.OnLifeLost += UpdateBubbleUI;
        
    }

    private void OnDisable()
    {
        GameManager.Instance.OnUpdatePlayerCoin -= UpdateCoinUI;
        bubble.OnLifeLost -= UpdateBubbleUI;
    }


    private void UpdateCoinUI(int coin)
    {
        uIcoin.Sync(coin);
    }
    
    private void UpdateBubbleUI(int life)
    {
        uIBubbleLife.Sync(life);
    }

    public void BuyDuck(DuckData duck)
    {
        GameManager.Instance.Buy<DuckData>(duckManager, duck);
    }

    public void BuyStat(StatUpgrade statUpgrade)
    {
        Satistique stat = statUpgrade.duck_type.stats[statUpgrade.statIndex];
        GameManager.Instance.Buy<Satistique>(statManager, stat);
    }
    
    public void BuyLock(Locker locker)
    {
        GameManager.Instance.Buy<Locker>(lockManager, locker);
    }
    
}
