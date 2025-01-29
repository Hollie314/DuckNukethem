using System;
using UnityEngine;
public class Duck : MonoBehaviour
{
    [HideInInspector]
    public DuckSpawner spawner;
    public Player player;
    public Bubble bubble;
    public float MoveSpeed = 3;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        bubble = GameObject.FindGameObjectWithTag("Bubble").GetComponent<Bubble>();
    }

    public void Move()
    { 
        transform.position = new Vector3(transform.position.x + MoveSpeed*Time.deltaTime, transform.position.y, 0);
    }

    public void Die(int NumberOfAtkUntilDie,int Add)
    {
        spawner.KillDuck(this);
        bubble.SubtractBubble(NumberOfAtkUntilDie);
        player.SetCoin(player.GetCoin() + Add);
    }
}