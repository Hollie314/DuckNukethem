using System.Collections;
using TMPro;
using UnityEngine;

public class AutomatisateButton : MonoBehaviour
{
    public TextMeshProUGUI autoCostText;
    public Soldier soldier;
    Player player;
    public int upCost = 1;
    public int addCost = 1;
    bool isAuto = false;
    float timerSpawn = 10f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        autoCostText.text = upCost.ToString();
    }

    public void AutoSpawn()
    {
        if (upCost <= player.GetCoin() && player.GetCoin() - upCost != 0)
        {
            if (isAuto == false)
            {
                StartCoroutine(SpawnDuck());
            }
            else
            {
                timerSpawn -= 0.1f;
            }
            player.SetCoin(player.GetCoin() - upCost);
            upCost += addCost;
            autoCostText.text = upCost.ToString();
            addCost *= 2;
        }
        IEnumerator SpawnDuck()
        {
            Instantiate(soldier);
            yield return new WaitForSeconds(timerSpawn);
            StartCoroutine(SpawnDuck());
        }
    }
}
