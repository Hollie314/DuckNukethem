using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Player player;
    public void UnlockButton(int coinNeed)
    {
        if (coinNeed <= player.GetCoin())
        {
            Destroy(gameObject);
            player.SetCoin(player.GetCoin() - coinNeed);
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
