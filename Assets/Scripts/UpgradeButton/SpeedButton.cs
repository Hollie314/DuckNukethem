using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeedButton : MonoBehaviour
{
    public TextMeshProUGUI speedCostText;
    public Soldier soldier;
    Player player;
    public int upCost = 1;
    public int addCost = 1;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        speedCostText.text = upCost.ToString();
    }

    public void AddSpeed()
    {
        if (upCost <= player.GetCoin() && player.GetCoin() - upCost != 0)
        {
            soldier.MoveSpeed += 20f;
            player.SetCoin(player.GetCoin() - upCost);
            upCost += addCost;
            speedCostText.text = upCost.ToString();
            addCost *= 2;
        }
    }
}
