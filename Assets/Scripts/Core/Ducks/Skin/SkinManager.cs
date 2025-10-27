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
        [field: SerializeField] public List<DuckSkin> UnlockedDucksSkins { get; private set;}
        [field: SerializeField] public List<DuckSkin> LockedDucksSkins { get; private set;}
        
        private bool isRandomSelected=false;
        private Dictionary<DuckType, DuckSkin> skinSelectedByDucks;
        private Dictionary<DuckType, List<DuckSkin>> unlockedSkinsByDucks;

        
        /*
         * subscribe to Managers events
         */
        private void OnEnable()
        {
            GameManager.Instance.OnBubbleExploded += UnlockNewSkin;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnBubbleExploded -= UnlockNewSkin;
        }
        
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


        private void UnlockNewSkin(int lvlBubble)
        {
            if (lvlBubble % 2==0)
            {
                UnlockRandomSKin();
            }
        }
        
        public void UnlockRandomSKin()
        {
            if (LockedDucksSkins.Count > 0)
            {
                int index = Random.Range(0, LockedDucksSkins.Count);
                DuckSkin duckSkin = LockedDucksSkins[index];
                duckSkin.Unlock();
                LockedDucksSkins.Remove(duckSkin);
                UnlockedDucksSkins.Add(duckSkin);
            }
        }

        public void SwapSkin(Duck duck)
        {
            AnimatorOverrideController overrideController = new AnimatorOverrideController(duck.Animator.runtimeAnimatorController);
            overrideController["Walk"] = GetSkin(duck.DuckType).walkAnimation;
            
            var anims = new List<KeyValuePair<AnimationClip, AnimationClip>>();
            foreach (var a in overrideController.animationClips)
                anims.Add(new KeyValuePair<AnimationClip, AnimationClip>(a, GetSkin(duck.DuckType).walkAnimation));
            
            overrideController.ApplyOverrides(anims);
            duck.Animator.runtimeAnimatorController = overrideController;
        }
    }
}