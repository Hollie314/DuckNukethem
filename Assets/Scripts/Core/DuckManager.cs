using System;
using System.Collections.Generic;
using UnityEngine;

public class DuckManager : MonoBehaviour, IAffordable<DuckData>
{
   
   //list of all category of ducks
   private DuckData[] ducks;
   //where to spawn our ducks
   [field: SerializeField] private Transform Spawnlocation;
   //a pool for each category of ducks
   private Dictionary<DuckData, PoolingSystem<Duck_>> dictionaryOfPoolOfDuck;

   //List of all active duck owned by the player
   private List<Duck_> playerDucks;
   //The big scary bubble we fight
   [field: SerializeField]
   private Bubble boss_bubble;

   private void Awake()
   {
      //retrieve all data of ducks
      ducks = GameController.GameDatabase.Ducks;
      
      //instantiate the pools
      dictionaryOfPoolOfDuck = new Dictionary<DuckData, PoolingSystem<Duck_>>();
      foreach (var duck_type in ducks)
      {
          dictionaryOfPoolOfDuck[duck_type] = new PoolingSystem<Duck_>(duck_type.duck_prefab, 10, Spawnlocation);
      }

      playerDucks = new List<Duck_>();
   }

   private void Update()
   {
       //update all ducks movements
       foreach (var duck in playerDucks)
       {
           duck.Move();
       }
   }

   public void SpawnDuck(DuckData duck_category)
   {
       if (dictionaryOfPoolOfDuck.TryGetValue(duck_category, out var pool))
       {
           Duck_ duck = pool.GetFromPool();
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
   private void AttackBubble(DuckData duckType, Duck_ duck)
   {
       Debug.Log("dégat : "+duckType.GetDammage());
       boss_bubble.LooseLife(duckType.GetDammage());
       DespawnDuck(duckType,duck);
       GameManager.Instance.GainCoin(duckType.GetCoinGain());
   }
   
   //goodbye duck
   private void DespawnDuck(DuckData duckType, Duck_ duck)
   {
       if (dictionaryOfPoolOfDuck.TryGetValue(duckType, out var pool))
       {
           pool.ReturnToPool(duck);
           playerDucks.Remove(duck);
           duck.OnTargetReached -= AttackBubble;
       }
   }

   //If duck can be buy, duck shall be spawn
   public bool Buy(ref int coin, DuckData product)
   {
       if (coin > product.cost)
       {
           coin -= product.cost;
           SpawnDuck(product);
           return true;
       }
       return false;
   }
}
