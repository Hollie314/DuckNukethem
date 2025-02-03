using TMPro;
using UnityEngine;

public class CoinGainButton : MonoBehaviour
{
    public TextMeshProUGUI coinGainCostText;
    public Soldier soldier;
    Player player;
    public int upCost = 1;
    public int addCost = 1;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        coinGainCostText.text = upCost.ToString();
    }

    public void AddCoinGain()
    {
        if (upCost <= player.GetCoin() && player.GetCoin() - upCost != 0)
        {
            soldier.CoinGain += 1;
            player.SetCoin(player.GetCoin() - upCost);
            upCost += addCost;
            coinGainCostText.text = upCost.ToString();
            addCost *= 2;
        }
    }
}
