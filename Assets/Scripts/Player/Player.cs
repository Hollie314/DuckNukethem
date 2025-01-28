using System;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int coin;

    public TextMeshProUGUI coinText;

    private void Start()
    {
        SetCoin(GetCoin());
    }

    public int GetCoin()
    {
        return coin;
    }

    public void SetCoin(int newValue)
    {
        this.coin = newValue;
        coinText.text = coin.ToString();
    }

    public void AddCoin(int amount)
    {
        this.coin += amount;
        SetCoin(GetCoin());
    }
}
