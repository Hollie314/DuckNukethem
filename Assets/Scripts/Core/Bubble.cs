using System;
using System.Collections;
using Core.Interface;
using Core.Statistics;
using TMPro;
using UnityEngine;

public class Bubble : MonoBehaviour, IDamagable
{
    private int MaxHealthPoint = 1;
    public int CurrentHealthPoint { get; private set; }
    public Animator animator;
    private int bubbleLevel = 0;
    private static readonly int Explode = Animator.StringToHash("IsDead");
    private static readonly int GetHit = Animator.StringToHash("IsHit");

    [field: SerializeField] public UpgradeFormulaData UpgradeStatFormula { get; private set; }
    
    private void Start()
    {
        animator.Play("Spawn");
        CurrentHealthPoint = MaxHealthPoint;
    }

    private void ResetBubbleNumber()
    {
        MaxHealthPoint = UpgradeStatFormula.CalculateValue(MaxHealthPoint, bubbleLevel);
        CurrentHealthPoint = MaxHealthPoint;
        bubbleLevel++;
        animator.SetTrigger(Explode);
        GameManager.Instance.UpdateBubbleExplode(bubbleLevel);
    }
    
    public void TakeDamages(int amount)
    {
        this.CurrentHealthPoint -= amount;
        animator.SetTrigger(GetHit);
        if (CurrentHealthPoint <= 0)
        {
            ResetBubbleNumber();
        }
        GameManager.Instance.UpdateBubbleLife(CurrentHealthPoint);
    }
}    