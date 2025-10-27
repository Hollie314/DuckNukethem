using System;
using System.Collections.Generic;
using Core.Enum;
using Core.Interface;
using UnityEngine;

public class DuckManager : MonoBehaviour
{
   
   //list of all category of ducks
   private DuckData[] duckData;
   //where to spawn our ducks
   [field: SerializeField] private Transform Spawnlocation;
   //a pool for each category of ducks
   private Dictionary<DuckType, PoolingSystem<Duck>> dictionaryOfPoolOfDuck;
   //Link to easly access each duckdata by giving its type
   private Dictionary<DuckType,DuckData> duckDataByType;
   
   //List of all active duck owned by the player
   private List<Duck> playerDucks;

   private void Awake()
   {
      //retrieve all data of ducks
      DuckData[] ducks = GameController.GameDatabase.Ducks;
      
      //init all tables, lists and dictionaries
      dictionaryOfPoolOfDuck = new Dictionary<DuckType, PoolingSystem<Duck>>();
      duckDataByType = new Dictionary<DuckType, DuckData>();
      duckData = new DuckData[ducks.Length];
      playerDucks = new List<Duck>();
      
      //clone SO for runtimes copies
      for (int i = 0; i < ducks.Length; i++)
      {
          duckData[i] = Instantiate(ducks[i]);
          Debug.Log(ducks[i].DuckType);
      }
      
      //create pool of gameobject for each type of duck
      foreach (var duck_type in duckData)
      {
          dictionaryOfPoolOfDuck[duck_type.DuckType] = new PoolingSystem<Duck>(duck_type.duck_prefab, 10, Spawnlocation);
          duckDataByType[duck_type.DuckType] = duck_type;
      }
   }
   
   private void Update()
   {
       //update all ducks movements that are on the board
       foreach (var duck in playerDucks)
       {
           if(TryGetDuckStat(duck.DuckType, StatType.Speed, out Statistic stat))
           {
               duck.Move(stat.CurrentStatValue);
           }
       }
   }

   public bool TryGetDuckData(DuckType duckType, out DuckData data) => duckDataByType.TryGetValue(duckType, out data);
   

   public bool TryGetDuckStat(DuckType duckType,StatType statType,out Statistic stat)
   {
       stat = null;
       return TryGetDuckData(duckType, out DuckData duckData) && duckData.TryGetStat(statType, out stat);
   }
   
   public void SpawnDuck(DuckType duckType)
   {
       if (dictionaryOfPoolOfDuck.TryGetValue(duckType, out var pool))
       {
           Duck duck = pool.GetFromPool();
           if (!duck)
           {
               return;
           }
           playerDucks.Add(duck);
           GameManager.Instance.SkinManager.SwapSkin(duck);
           // Subscribe to the despawn event
           duck.OnTargetReached += AttackBubble;
       }
   }

   //deal damage to the bubble and despawn duck
   private void AttackBubble(Duck duck, IDamagable damagable)
   {
       if (TryGetDuckData(duck.DuckType, out DuckData duckData))
       {
           if (duckData.TryGetStat(StatType.Damage, out Statistic damage))
           {
               damagable.TakeDamages((int)damage.CurrentStatValue);
           }
           if (duckData.TryGetStat(StatType.Gain, out Statistic gain))
           {
               GameManager.Instance.GainCoin((int)gain.CurrentStatValue);
           }
       }
       DespawnDuck(duck.DuckType,duck);
   }
   
   //goodbye duck
   private void DespawnDuck(DuckType duckType, Duck duck)
   {
       if (dictionaryOfPoolOfDuck.TryGetValue(duckType, out var pool))
       {
           pool.ReturnToPool(duck);
           playerDucks.Remove(duck);
           duck.OnTargetReached -= AttackBubble;
       }
   }

   //If duck can be buy, duck shall be spawn
   public bool BuyDuck(DuckType product)
   {
       if (TryGetDuckData(product, out DuckData duckData) && TrySpendCoins(duckData.cost))
       {
           SpawnDuck(product);
           return true;
       }
       return false;
   }

   //If stat can be buy, stat shall be upgraded
   public bool BuyStatUpgrade(StatType statType, DuckType duckType, out int currentStatValue, out int currentStatPrice)
   {
       if (TryGetDuckStat(duckType, statType, out Statistic statistic) && TrySpendCoins(statistic.CurrentPrice))
       {
           statistic.Upgrade();
           currentStatValue = (int)statistic.CurrentStatValue;
           currentStatPrice = (int)statistic.CurrentPrice;
           return true;
       }
       currentStatValue = 0;
       currentStatPrice = 0;
       return false;
   }

   private bool TrySpendCoins(int cost)
   {
       return GameManager.Instance.TrySpendCoins(cost);
   }
}
