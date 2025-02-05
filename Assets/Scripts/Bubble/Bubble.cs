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
    public RuntimeAnimatorController bubbleAnimator;
    public RuntimeAnimatorController bubbleAnimator2;
    public RuntimeAnimatorController bubbleAnimator3;
    private void Start()
    {
        Debug.Log("les animations clips wtf : " + animator.runtimeAnimatorController.animationClips[0]+" si je dis pas de connerie c'est la même chose que : "+bubbleAnimator);
        animator.Play("spawn");
        //animator.runtimeAnimatorController = bubbleAnimator;
        totalBubble = MaxBubble;
        SetBubbleNumber(GetBubble());
    }

    private void ResetBubbleNumber()
    {
        MaxBubble *= 10;
        totalBubble = MaxBubble;
        SetBubbleNumber(totalBubble);
        animator.SetTrigger("Explode");
        //animator.runtimeAnimatorController = bubbleAnimator2;
        //StartCoroutine(RespawnBubble());
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
            //animator.runtimeAnimatorController = bubbleAnimator3;
            animator.SetTrigger("Get_Hit");
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