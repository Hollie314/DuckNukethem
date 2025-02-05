using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckSpawner : MonoBehaviour
{
    bool canSpawn = true;
    Coin coin;
    public Transform playerUI; //position de spawn
    
    public List<Duck> ducks = new List<Duck>();

    private void Start()
    {
        coin = GameObject.FindGameObjectWithTag("Coin").GetComponent<Coin>();
    }

    public void SpawnDuck(Soldier prefab)
    {
        if (canSpawn == true && GetDuckNumber()<=9 && coin.CanISpawnDuck(prefab.Cost) == true)
        {
            Duck duck = Instantiate(prefab, playerUI);
            duck.spawner = this;
            ducks.Add(duck);
            canSpawn = false;
            StartCoroutine(canISpawn());
        }
        IEnumerator canISpawn()
        {
            yield return new WaitForSeconds(0.5f);
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