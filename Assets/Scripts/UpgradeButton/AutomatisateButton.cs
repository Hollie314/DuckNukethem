using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AutomatisateButton : MonoBehaviour
{
    public Soldier[] soldier;
    DuckSpawner duckSpawner;
    Player player;
    public int cost = 100;
    float timerSpawn = 3f;
    public Transform playerUI;
    public TextMeshProUGUI autoSpawnText;

    private void Start()
    {
        autoSpawnText.text = cost.ToString();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void AutoSpawn()
    {
        if (cost <= player.GetCoin() && player.GetCoin() - cost != 0)
        {
                StartCoroutine(SpawnDuck());
                player.SetCoin(player.GetCoin() - cost);
                cost *= 10;
                autoSpawnText.text = cost.ToString();
                
        }
        IEnumerator SpawnDuck()
        {
            foreach (Soldier soldiers in soldier)
            {
                Duck duck = Instantiate(soldiers, playerUI);
                duck.tag = "AutoSpawnSoldier";
                yield return new WaitForSeconds(timerSpawn);
            }
            
            StartCoroutine(SpawnDuck());
        }
    }
}
