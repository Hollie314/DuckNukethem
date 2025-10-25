using System;
using System.Collections.Generic;
using Core.Enum;
using Core.Interface;
using UnityEngine;

public class DuckManager : MonoBehaviour, IAffordable<DuckType>
{
   
   //list of all category of ducks
   private DuckData[] duckData;
   //where to spawn our ducks
   [field: SerializeField] private Transform Spawnlocation;
   //a pool for each category of ducks
   private Dictionary<DuckData, PoolingSystem<Duck>> dictionaryOfPoolOfDuck;

   //List of all active duck owned by the player
   private List<Duck> playerDucks;
   //The big scary bubble we fight
   [field: SerializeField]
   private Bubble boss_bubble;

   private void Awake()
   {
      //retrieve all data of ducks
      DuckData[] ducks = GameController.GameDatabase.Ducks;
      duckData = new DuckData[ducks.Length];
      //clone SO for runtimes copies
      for (int i = 0; i < ducks.Length; i++)
      {
          duckData[i] = Instantiate(ducks[i]);
          Debug.Log(ducks[i].DuckType);
      }
      
      //instantiate the pools
      dictionaryOfPoolOfDuck = new Dictionary<DuckData, PoolingSystem<Duck>>();
      foreach (var duck_type in duckData)
      {
          dictionaryOfPoolOfDuck[duck_type] = new PoolingSystem<Duck>(duck_type.duck_prefab, 10, Spawnlocation);//create pull of gameobject
          duck_type.stats = new Statistique[3];
          //in order : damages, gains, speed
          duck_type.stats[0] = GameManager.Instance.StatManager.AddStat(duck_type.BaseUpgradePrice, duck_type.damage,
              StatType.Damage, duck_type.UpgradeStatAndPriceMultiplier);
          duck_type.stats[1] = GameManager.Instance.StatManager.AddStat(duck_type.BaseUpgradePrice, duck_type.coingain,
              StatType.Gain, duck_type.UpgradeStatAndPriceMultiplier);
          duck_type.stats[2] = GameManager.Instance.StatManager.AddStat(duck_type.BaseUpgradePrice, duck_type.speed,
              StatType.Speed, duck_type.UpgradeStatAndPriceMultiplier);
      }

      playerDucks = new List<Duck>();
   }

   private void Update()
   {
       //update all ducks movements that are on the board
       foreach (var duck in playerDucks)
       {
           if (TryGetDuckData(duck.DuckType, out DuckData duckData))
           {
               duck.Move(duckData.GetSpeed());
           }
       }
   }

   public bool TryGetDuckData(DuckType duckType,out DuckData data)
   {
       foreach (var duck in duckData)
       {
           if (duck.DuckType == duckType)
           {
               data = duck;
               return true;
           }
       }
       data = null;
       return false;
   }
   
   public void SpawnDuck(DuckData duck_category)
   {
       if (dictionaryOfPoolOfDuck.TryGetValue(duck_category, out var pool))
       {
           Duck duck = pool.GetFromPool();
           if (!duck)
           {
               return;
           }
           playerDucks.Add(duck);
           
           // Subscribe to the despawn event
           duck.OnTargetReached += AttackBubble;
       }
   }

   //deal damage to the bubble and despawn duck
   private void AttackBubble(Duck duck, IDamagable damagable)
   {
       if (TryGetDuckData(duck.DuckType, out DuckData duckData))
       {
           Debug.Log("dégat : "+duckData.GetDammage());
           damagable.TakeDamages(duckData.GetDammage());
           DespawnDuck(duckData,duck);
           GameManager.Instance.GainCoin(duckData.GetCoinGain());
       }
   }
   
   //goodbye duck
   private void DespawnDuck(DuckData duckType, Duck duck)
   {
       if (dictionaryOfPoolOfDuck.TryGetValue(duckType, out var pool))
       {
           pool.ReturnToPool(duck);
           playerDucks.Remove(duck);
           duck.OnTargetReached -= AttackBubble;
       }
   }

   //If duck can be buy, duck shall be spawn
   public bool Buy(ref int coin, DuckType product)
   {
       if (TryGetDuckData(product, out DuckData duckData))
       {
           if (coin >= duckData.cost)
           {
               coin -= duckData.cost;
               SpawnDuck(duckData);
               return true;
           }
       }
       return false;
   }
}
