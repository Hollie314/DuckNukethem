using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    private bool window_opened = false;
    public GameObject UpgradeUi;
    public void upgradeUi()
    {
        UpgradeUi.SetActive(!window_opened);
        window_opened = !window_opened;
    }
}
