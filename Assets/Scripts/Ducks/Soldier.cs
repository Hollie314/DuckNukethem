using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Soldier : Duck
{
    bool StopMoving = false;
    public int nbAtk = 1;
    public int Cost;
    public int CoinGain;
    void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Bubble"))
            {
                StopMoving = true;
            }
        }
    void Update()
    {
        if (StopMoving == false)
        {
            Move();
        }
        else
        {
            StartCoroutine(DestroyDuck());
        }
    }

    IEnumerator DestroyDuck()
    {
        yield return new WaitForSeconds(100f/MoveSpeed);
        Die(nbAtk, CoinGain);
    }
}
