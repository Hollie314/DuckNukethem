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
}
