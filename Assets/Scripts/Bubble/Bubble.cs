using System;
using TMPro;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    private int totalBubble = 1000;
    public TextMeshProUGUI bubbleText;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Soldier"))
        {
            SubtractBubble(1);
        }
    }

    private void Start()
    {
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
    void SubtractBubble(int amount)
        {
            this.totalBubble -= amount;
            SetBubbleNumber(GetBubble());
        }
}    