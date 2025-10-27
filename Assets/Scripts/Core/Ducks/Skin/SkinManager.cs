using System;
using System.Collections.Generic;
using Core.Enum;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

namespace Core.Ducks.Skin
{
    public class SkinManager : MonoBehaviour
    {
        [field: SerializeField] public DuckSkin[] UnlockedDucksSkins { get; private set;}
        [field: SerializeField] public DuckSkin[] LockedDucksSkins { get; private set;}
        
        private bool isRandomSelected=false;
        private Dictionary<DuckType, DuckSkin> skinSelectedByDucks;
        private Dictionary<DuckType, List<DuckSkin>> unlockedSkinsByDucks;

        private void Start()
        {
            unlockedSkinsByDucks = new Dictionary<DuckType, List<DuckSkin>>();
            skinSelectedByDucks = new Dictionary<DuckType, DuckSkin>();

            foreach (var unlockedDucksSkin in UnlockedDucksSkins)
            {
                if (!unlockedSkinsByDucks.ContainsKey(unlockedDucksSkin.DuckType))
                {
                    unlockedSkinsByDucks[unlockedDucksSkin.DuckType] = new List<DuckSkin>();
                }
                unlockedSkinsByDucks[unlockedDucksSkin.DuckType].Add(unlockedDucksSkin);
            }
            foreach (var unlockedSkinsByDuck in unlockedSkinsByDucks.Keys)
            {
                if (unlockedSkinsByDucks[unlockedSkinsByDuck].Count > 0)
                {
                    skinSelectedByDucks[unlockedSkinsByDuck] = unlockedSkinsByDucks[unlockedSkinsByDuck][0];
                }
            }
        }

        public bool SetSelectedSkin(DuckSkin duckSkin, out DuckSkin lastSelected)
        {
            lastSelected = skinSelectedByDucks[duckSkin.DuckType];
            if (duckSkin.IsLocked)
                return false;
            skinSelectedByDucks[duckSkin.DuckType] = duckSkin;
            return true;
        }

        public DuckSkin GetSkin(DuckType duckType)
        {
            if (!isRandomSelected)
            {
                return skinSelectedByDucks[duckType];
            }
            return GetRandomDuckSkin(unlockedSkinsByDucks[duckType]);
        }
        
        private DuckSkin GetRandomDuckSkin(List<DuckSkin> duckSkins)
        {
            if (duckSkins.Count > 0)
            {
                int index = Random.Range(0, duckSkins.Count);
                return duckSkins[index];
            }
            return null;
        }

        public void toogleRandom()
        {
            isRandomSelected = !isRandomSelected;
        }
    }
}