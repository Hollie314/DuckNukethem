using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    private int FlipFlop;
    public GameObject UpgradeUi;
    public void upgradeUi()
    {
        FlipFlop += 1;
        if (FlipFlop == 1)
        {
            UpgradeUi.GetComponent<Canvas>().enabled = true;
        }
        else
        {
            UpgradeUi.GetComponent<Canvas>().enabled = false;
            FlipFlop = 0;
        }
    }
}
