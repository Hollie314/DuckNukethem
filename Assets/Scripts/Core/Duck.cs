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
            transform.Translate(Vector3.right * (Time.deltaTime * (float)duck_category.GetSpeed()));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bubble"))
        {
            OnTargetReached?.Invoke(duck_category, this);
        }
    }
}
