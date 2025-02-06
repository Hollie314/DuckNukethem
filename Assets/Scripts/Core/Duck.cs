using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Duck_ : MonoBehaviour
{
    [field: SerializeField]
    private DuckData duck_category;

    public event Action<DuckData, Duck_> OnTargetReached;


    public void Move()
    {
        if (transform)
        {
            transform.Translate(Vector3.right * (Time.deltaTime * duck_category.speed));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bubble"))
        {
            Debug.Log(" We hit the bubble ");
        }
    }
}
