using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    private int MaxBubble = 1;
    private int totalBubble;
    public Animator animator;
    
    public event Action<int> OnLifeLost;
    private void Start()
    {
        animator.Play("Spawn");
        totalBubble = MaxBubble;
        SetBubbleNumber(GetBubble());
    }

    private void ResetBubbleNumber()
    {
        MaxBubble *= 10;
        totalBubble = MaxBubble;
        animator.SetTrigger("Explode");
    }
    public int GetBubble()
    {
        return totalBubble;
    }

    public void SetBubbleNumber(int amount)
    {
        this.totalBubble = amount;
    }
    
    public void LooseLife(int amount)
        {
            this.totalBubble -= amount;
            animator.SetTrigger("GetHit");
            if (totalBubble <= 0)
            {
                ResetBubbleNumber();
            }
            OnLifeLost?.Invoke(totalBubble); 
        }
}    