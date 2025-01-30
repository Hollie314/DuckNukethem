using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AutomatisateButton : MonoBehaviour
{
    public Soldier[] soldier;
    DuckSpawner duckSpawner;
    Player player;
    public int Cost = 1;
    float timerSpawn = 5f;
    public Transform playerUI;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void AutoSpawn()
    {
        if (Cost <= player.GetCoin() && player.GetCoin() - Cost != 0)
        {
                StartCoroutine(SpawnDuck());
        }
        IEnumerator SpawnDuck()
        {
            foreach (Soldier soldiers in soldier)
            {
                soldiers.tag = "AutoSpawnSoldier";
                Instantiate(soldiers, playerUI);
                yield return new WaitForSeconds(timerSpawn);
            }
            
            StartCoroutine(SpawnDuck());
        }
    }
}
