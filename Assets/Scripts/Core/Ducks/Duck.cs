using System;
using Core.Enum;
using Core.Interface;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Duck : MonoBehaviour
{
    [field : SerializeField] public DuckType DuckType { get; private set; }
    [field : SerializeField] public Image SpriteRenderer { get; private set; }
    
    public event Action<Duck, IDamagable> OnTargetReached;
    
    public void Move(float speed)
    {
        if (transform)
        {
            transform.Translate(Vector3.right * (Time.deltaTime * speed));
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bubble"))
        {
            IDamagable damagable = other.GetComponent<IDamagable>();
            OnTargetReached?.Invoke(this, damagable);
        }
    }

    public void SwapSkin(Sprite sprite)
    {
        SpriteRenderer.sprite = sprite;
    }
}
