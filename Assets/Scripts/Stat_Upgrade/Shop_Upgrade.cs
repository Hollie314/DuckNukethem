using UnityEngine;

public class Shop_Upgrade : MonoBehaviour
{
    private bool window_opened = false;
    public GameObject UpgradeUi;
    
    public void OpenShop()
    {
        UpgradeUi.SetActive(!window_opened);
        window_opened = !window_opened;
    }
}
