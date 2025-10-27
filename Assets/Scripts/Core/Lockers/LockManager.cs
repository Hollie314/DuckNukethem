using UnityEngine;

public class LockManager : MonoBehaviour
{
   public bool BuyLocker(UI_Locker uiLocker)
   {
      if (GameManager.Instance.TrySpendCoins(uiLocker.Price))
      {
         uiLocker.Unlock();
         return true;
      }
      return false;
   }
}
