using TMPro;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    private int totalBubble = 1000;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SubtractBubble();
        }
    }

    void AddBubble()
        {
            totalBubble += 10;
            Debug.Log(totalBubble);
        }

    void SubtractBubble()
        {
            totalBubble -= 1;
            Debug.Log(totalBubble);
        }
}    