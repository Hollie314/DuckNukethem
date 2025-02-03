using System;
using TMPro;
using UnityEngine;

public class DuckInfo : MonoBehaviour
{
    public Soldier soldier;
    public TextMeshProUGUI soldierSpeed;
    public TextMeshProUGUI soldierDamage;
    public TextMeshProUGUI soldierCoinGain;

    private void Update()
    {
        soldierSpeed.text = soldier.MoveSpeed.ToString();
        soldierDamage.text = soldier.nbAtk.ToString();
        soldierCoinGain.text = soldier.CoinGain.ToString();
    }
}
