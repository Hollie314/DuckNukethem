using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeedButton : MonoBehaviour
{
    public TextMeshProUGUI costText;
    Duck duck;
    Player player;
    private int upCost = 1;
    int addCost = 1;

    private void Start()
    {
        duck = GameObject.FindGameObjectWithTag("Duck").GetComponent<Duck>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        costText.text = upCost.ToString();
    }

    public void AddSpeed()
    {
        if (upCost <= player.GetCoin() && player.GetCoin() - upCost != 0)
        {
            duck.MoveSpeed += 0.1f;
            player.SetCoin(player.GetCoin() - upCost);
            upCost += addCost;
            costText.text = upCost.ToString();
            addCost *= 2;
        }
        
    }
}
