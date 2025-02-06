using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private UI_Coin uIcoin; 
    
    /*
     * subscribe to questionManagers events
     */
    private void OnEnable()
    {
        GameManager.Instance.OnUpdatePlayerCoin += UpdateCoinUI;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnUpdatePlayerCoin -= UpdateCoinUI;
    }


    private void UpdateCoinUI(int coin)
    {
        uIcoin.Sync(coin);
    }

    public void BuyDuck(IAffordable<DuckData> manager, DuckData duck)
    {
        GameManager.Instance.Buy<>(manager, duck);
    }

    public void BuyStat(IAffordable<UpgradeSystem> manager, DuckData duck, int statIndex)
    {
        Satistique stat = duck.stats[statIndex];
        GameManager.Instance.Buy<>(manager, stat);
    }
    
}
