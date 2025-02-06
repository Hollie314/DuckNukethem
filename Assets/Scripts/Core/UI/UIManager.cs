using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private UI_Text uIcoin;
    [SerializeField]
    private UI_Text uIBubbleLife;

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

    public void BuyDuck(IAffordable<DuckData> manager, DuckData duck)
    {
        GameManager.Instance.Buy<DuckData>(manager, duck);
    }

    public void BuyStat(IAffordable<Satistique> manager, DuckData duck, int statIndex)
    {
        Satistique stat = duck.stats[statIndex];
        GameManager.Instance.Buy<Satistique>(manager, stat);
    }
    
}
