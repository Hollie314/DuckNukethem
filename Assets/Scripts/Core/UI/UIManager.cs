using System;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private UI_Text uIcoin;
    [SerializeField]
    private UI_Text uIBubbleLife;
    
    [field:SerializeField]
    private UI_Text[] stats_text;
    [field:SerializeField]
    private StatUpgrade[] statUp;
    

    
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
        GameManager.Instance.OnStatUp += UpdateStatUI;
        GameManager.Instance.OnBubbleLifeChange += UpdateBubbleUI;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnUpdatePlayerCoin -= UpdateCoinUI;
        GameManager.Instance.OnStatUp -= UpdateStatUI;
        GameManager.Instance.OnBubbleLifeChange -= UpdateBubbleUI;
        Debug.Log("sah");
    }


    private void UpdateCoinUI(int coin)
    {
        uIcoin.Sync(coin);
    }
    
    private void UpdateBubbleUI(int life)
    {
        uIBubbleLife.Sync(life);
    }
    
    private void UpdateStatUI(int index, int value)
    {
        Debug.Log(" la stat n° "+ index +" prend la valeur : "+value);
        //stats_text[index].GetComponent<TextMeshPro>().text = value.ToString();
        stats_text[index].Sync(value);
    }

    public void BuyDuck(DuckData duck)
    {
        GameManager.Instance.Buy<DuckData>(duckManager, duck);
    }

    public void BuyStat(StatUpgrade statUpgrade)
    {
        ref Satistique stat = ref statUpgrade.duck_type.stats[statUpgrade.statIndex];
        GameManager.Instance.Buy<Satistique>(statManager, stat);
    }
    
    public void BuyLock(Locker locker)
    {
        GameManager.Instance.Buy<Locker>(lockManager, locker);
    }
    
}
