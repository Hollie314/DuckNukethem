using System;
using System.Collections;
using UnityEngine;

public class Soldier2 : Duck
{
    Boolean StopMoving = false;
    
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
        Die();
    }
}
