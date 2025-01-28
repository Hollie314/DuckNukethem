using System;
using UnityEngine;
public class Duck : MonoBehaviour
{
    [HideInInspector]
    public DuckSpawner spawner;
    public Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void Move()
    { 
        transform.position = new Vector3(transform.position.x + 3*Time.deltaTime, transform.position.y, 0);
    }

    public void Die(int NumberOfAtkUntilDie)
    {
        spawner.KillDuck(this);
        player.SetCoin(player.GetCoin() + NumberOfAtkUntilDie);
    }
}