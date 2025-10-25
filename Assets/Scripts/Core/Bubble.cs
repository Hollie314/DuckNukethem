using System;
using System.Collections;
using Core.Interface;
using TMPro;
using UnityEngine;

public class Bubble : MonoBehaviour, IDamagable
{
    private int MaxHealthPoint = 1;
    private int currentHealthPoint;
    public Animator animator;
    
    private void Start()
    {
        animator.Play("Spawn");
        currentHealthPoint = MaxHealthPoint;
        SetBubbleNumber(GetBubble());
        GameManager.Instance.UpdateBubbleLife(currentHealthPoint);
    }

    private void ResetBubbleNumber()
    {
        MaxHealthPoint *= 10;
        currentHealthPoint = MaxHealthPoint;
        animator.SetTrigger("Explode");
    }
    public int GetBubble()
    {
        return currentHealthPoint;
    }

    public void SetBubbleNumber(int amount)
    {
        this.currentHealthPoint = amount;
    }
    
    public void TakeDamages(int amount)
    {
        this.currentHealthPoint -= amount;
        animator.SetTrigger("GetHit");
        if (currentHealthPoint <= 0)
        {
            ResetBubbleNumber();
        }
        GameManager.Instance.UpdateBubbleLife(currentHealthPoint);
    }
}    