using System;
using System.Collections;
using Core.Enum;
using UnityEngine;
using Random = UnityEngine.Random;

public class AutomateManager : MonoBehaviour
{
    [field : SerializeField] public int Cooldown { get; private set; }
    [field : SerializeField] public int unLockPrice { get; private set; }
    [field : SerializeField] public Statistic SpawnRateUpgrade { get; private set; }
    private bool IsUnlocked = false;

    [field: SerializeField] public DuckType[] DuckTypes;
    
    private Coroutine spawnRoutine;

    
    public bool BuyAutomateUpgrade(out int currentPrice)
    {
        if (!IsUnlocked)
        {
            return TryUnlock(out currentPrice);
        }
        else
        {
            return TryUpgrade(out currentPrice);
        }
    }

    private bool TryUnlock(out int currentPrice)
    {
        if (GameManager.Instance.TrySpendCoins(unLockPrice))
        {
            IsUnlocked = true;
            currentPrice = SpawnRateUpgrade.CurrentPrice;
            StartCoroutine(SpawnRoutine());
            return true;
        }
        currentPrice = unLockPrice;
        return false;
    }

    private bool TryUpgrade(out int currentPrice)
    {
        if (GameManager.Instance.TrySpendCoins(SpawnRateUpgrade.CurrentPrice))
        {
            SpawnRateUpgrade.Upgrade();
            currentPrice = SpawnRateUpgrade.CurrentPrice;
            return true;
        }
        currentPrice = SpawnRateUpgrade.CurrentPrice;
        return false;
    }

    private DuckType GetRandomDuckType()
    {
        if (DuckTypes.Length > 0)
        {
            int index = Random.Range(0, DuckTypes.Length);
            return DuckTypes[index];
        }
        return DuckType.BasicDuck;
    }
    
    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            for (int i = 0; i < SpawnRateUpgrade.CurrentStatValue; i++)
            {
                GameManager.Instance.DuckManager.SpawnDuck(GetRandomDuckType());
            }
            yield return new WaitForSeconds(Cooldown);
        }
    }
}
