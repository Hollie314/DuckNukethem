using UnityEngine;

public class LockUI : MonoBehaviour, IUnlockable
{
   
   private GameObject locker;
   private GameObject unlockedObject;
   
   public void Unlock()
   {
      locker.SetActive(false);
      unlockedObject.SetActive(true);
   }
}
