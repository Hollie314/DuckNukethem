using UnityEngine;

public class LockManager : MonoBehaviour, IUnlockable
{
   
   public void Unlock(GameObject toUnclock, GameObject locker)
   {
      locker.SetActive(false);
      toUnclock.SetActive(true);
   }

   public bool BuyLocker(Locker locker)
   {
      if (GameManager.Instance.TrySpendCoins(locker.Price))
      {
         Unlock(locker.Product, locker.Lock);
         return true;
      }
      return false;
   }
}
