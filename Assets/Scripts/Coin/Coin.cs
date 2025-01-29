using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public Player player;
    public Button button;
    public void UnlockButton(int coinNeed)
    {
        if (coinNeed <= player.GetCoin())
        {
            Destroy(gameObject);
            player.SetCoin(player.GetCoin() - coinNeed);
            if (gameObject.name == "UnlockSoldier3")
            {
                button.gameObject.GetComponent<Image>().enabled = true;
                button.enabled = true;
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
