using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AutomatisateButton : MonoBehaviour
{
    

    private void Start()
    {
        
    }

    public void AutoSpawn()
    {
        /*
        if (cost < player.GetCoin())
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
        */
    }
}
