using System;
using System.Collections;
using UnityEngine;

public class Soldier2 : Duck
{
    bool StopMoving = false;
    public int nbAtk = 2;
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
        yield return new WaitForSeconds(1f);
        Die(nbAtk);
    }
}
