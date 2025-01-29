using System;
using TMPro;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    private int MaxBubble = 1;
    private int totalBubble;
    public TextMeshProUGUI bubbleText;
    private void Start()
    {
        totalBubble = MaxBubble;
        SetBubbleNumber(GetBubble());
    }

    private void ResetBubbleNumber()
    {
        MaxBubble *= 10;
        totalBubble = MaxBubble;
        SetBubbleNumber(GetBubble());
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
            if (totalBubble <= 0)
            {
                ResetBubbleNumber();
            }
        }
}    