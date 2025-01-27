using System;
using UnityEngine;
public class Duck : MonoBehaviour
{
    public int NbAtk;
    public void Move()
    { 
        transform.position = new Vector3(transform.position.x + 3*Time.deltaTime, transform.position.y, 0);
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}