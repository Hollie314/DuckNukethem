using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public Player player;
    public GameObject thisButton;
    public Button buttonUpgrade;
    public void UnlockButton(int coinNeed)
    {
        if (coinNeed <= player.GetCoin() && player.GetCoin() - coinNeed >= 0)
        {
            thisButton.SetActive(false);
            player.SetCoin(player.GetCoin() - coinNeed);
            if (gameObject.name == "UnlockSoldier3")
            {
                buttonUpgrade.gameObject.GetComponent<Image>().enabled = true;
                buttonUpgrade.enabled = true;
            }
        }
    }

    public bool CanISpawnDuck(int coinNeed)
    {
        bool IveMoney = false;
        if (coinNeed <= player.GetCoin())
        {
            player.SetCoin(player.GetCoin() - coinNeed);
            IveMoney = true;
        }
        return IveMoney;
    }
}
