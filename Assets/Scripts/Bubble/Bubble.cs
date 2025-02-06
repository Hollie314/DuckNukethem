using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    private int MaxBubble = 1;
    private int totalBubble;
    public TextMeshProUGUI bubbleText;
    public Animator animator;
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
        SetBubbleNumber(totalBubble);
        animator.SetTrigger("Explode");
    }
    public int GetBubble()
    {
        return totalBubble;
    }

    public void SetBubbleNumber(int amount)
    {
        this.totalBubble = amount;
        bubbleText.text = amount.ToString();
    }
    public void LooseLife(int amount)
        {
            this.totalBubble -= amount;
            SetBubbleNumber(GetBubble());
            animator.SetTrigger("GetHit");
            if (totalBubble <= 0)
            {
                ResetBubbleNumber();
            }
        }

    IEnumerator RespawnBubble()
    {
        yield return new WaitForSeconds(0.5f);
        //animator.runtimeAnimatorController = bubbleAnimator;
    }
}    