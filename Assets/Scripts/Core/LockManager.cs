using UnityEngine;

public class LockManager : MonoBehaviour, IUnlockable, IAffordable<Locker>
{
   
   public void Unlock(GameObject toUnclock, GameObject locker)
   {
      locker.SetActive(false);
      toUnclock.SetActive(true);
   }

   public bool Buy(ref int coin, Locker locker)
   {
      if (coin > locker.Price )
      {
         coin -= locker.Price;
         Unlock(locker.Product, locker.Lock);
         return true;
      }
      return false;
   }
}
