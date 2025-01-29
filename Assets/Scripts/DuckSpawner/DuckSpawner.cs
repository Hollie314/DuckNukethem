using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using Object = System.Object;
public class DuckSpawner : MonoBehaviour
{
    DuckInFile duckInFile;
    bool canSpawn = true;
    Coin coin;
    
    private List<Duck> ducks = new List<Duck>();

    private void Start()
    {
        coin = GameObject.FindGameObjectWithTag("Coin").GetComponent<Coin>();
    }

    public void SpawnDuck(GameObject prefab)
    {
        if (canSpawn == true && GetDuckNumber()<=4 && coin.CanISpawnDuck(1) == true)
        {
            GameObject duckGo = Instantiate(prefab);
            Duck duck = duckGo.GetComponent<Duck>();
            duck.spawner = this;
            ducks.Add(duck);
            canSpawn = false;
            StartCoroutine(canISpawn());
        }
        IEnumerator canISpawn()
        {
            yield return new WaitForSeconds(1f);
            canSpawn = true;
        }
    }

    public void KillDuck(Duck duck)
    {
        Destroy(duck.gameObject);
        ducks.Remove(duck);
    }

    private int GetDuckNumber()
    {
        return ducks.Count;
    }
}