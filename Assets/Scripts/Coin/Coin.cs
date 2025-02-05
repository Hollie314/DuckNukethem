using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public Player player;
    public GameObject thisButton;
    public Button buttonUpgrade;
    public GameObject autoSpawnButton;
    public GameObject spawnButton;
    public void UnlockButton(int coinNeed)
    {
        if (coinNeed < player.GetCoin())
        {
            thisButton.SetActive(false);
            spawnButton.SetActive(true);
            player.SetCoin(player.GetCoin() - coinNeed);
            if (gameObject.name == "UnlockSoldier3")
            {
                buttonUpgrade.gameObject.GetComponent<Image>().enabled = true;
                buttonUpgrade.enabled = true;
                autoSpawnButton.SetActive(true);
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
