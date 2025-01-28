using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Soldier : Duck
{
    bool StopMoving = false;
    private int nbAtk = 1;
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
        Coin[] coins = GameObject.FindObjectsByType<Coin>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
        for (int i = 0; i < coins.Length; i++)
        {
            
        }
    }
}
