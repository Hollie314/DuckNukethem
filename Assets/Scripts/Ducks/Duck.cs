using System;
using UnityEngine;
public partial class Duck : MonoBehaviour
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
        transform.Translate(Vector3.right * Time.deltaTime * MoveSpeed);
    }

    public void Die(int NumberOfAtkUntilDie,int Add)
    {
        if (this.CompareTag("Soldier") == true)
            spawner.KillDuck(this);
        else if (this.CompareTag("AutoSpawnSoldier") == true)
        {
            Destroy(this.gameObject);
        }
        bubble.LooseLife(NumberOfAtkUntilDie);
        player.SetCoin(player.GetCoin() + Add);
    }
}