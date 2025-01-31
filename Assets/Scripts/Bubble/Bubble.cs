using System;
using System.Collections;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    private int MaxBubble = 1;
    private int totalBubble;
    public TextMeshProUGUI bubbleText;
    public Animator animator;
    public AnimatorController bubbleAnimator;
    public AnimatorController bubbleAnimator2;
    public AnimatorController bubbleAnimator3;
    private void Start()
    {
        animator.runtimeAnimatorController = bubbleAnimator;
        totalBubble = MaxBubble;
        SetBubbleNumber(GetBubble());
    }

    private void ResetBubbleNumber()
    {
        MaxBubble *= 10;
        totalBubble = MaxBubble;
        SetBubbleNumber(GetBubble());
        animator.runtimeAnimatorController = bubbleAnimator2;
        StartCoroutine(RespawnBubble());
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
    public void SubtractBubble(int amount)
        {
            this.totalBubble -= amount;
            SetBubbleNumber(GetBubble());
            animator.runtimeAnimatorController = bubbleAnimator3;
            if (totalBubble <= 0)
            {
                ResetBubbleNumber();
            }
        }

    IEnumerator RespawnBubble()
    {
        yield return new WaitForSeconds(0.5f);
        animator.runtimeAnimatorController = bubbleAnimator;
    }
}    