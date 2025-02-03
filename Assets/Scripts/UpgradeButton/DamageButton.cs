using TMPro;
using UnityEngine;

public class DamageButton : MonoBehaviour
{
    public TextMeshProUGUI damageCostText;
    public Soldier soldier;
    Player player;
    public int upCost = 1;
    public int addCost = 1;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        damageCostText.text = upCost.ToString();
    }

    public void AddDamage()
    {
        if (upCost <= player.GetCoin() && player.GetCoin() - upCost != 0)
        {
            soldier.nbAtk += 1;
            player.SetCoin(player.GetCoin() - upCost);
            upCost += addCost;
            damageCostText.text = upCost.ToString();
            addCost *= 2;
        }
    }
}
