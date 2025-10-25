using System;
using System.Collections.Generic;
using Core.Enum;
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
    private StatManager[] statUp;
    


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

    public void BuyDuck(int duckTypeID)
    {
        DuckType duckType = (DuckType)duckTypeID;
        GameManager.Instance.Buy<DuckType>(GameManager.Instance.DuckManager, duckType);
    }

    public void BuyStat(int statID)
    {
        GameManager.Instance.Buy<int>(GameManager.Instance.StatManager, statID);
    }
    
    public void BuyLock(Locker locker)
    {
        GameManager.Instance.Buy<Locker>(GameManager.Instance.LockManager, locker);
    }
    
}
