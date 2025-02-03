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
            UpgradeUi.GetComponent<CanvasGroup>().alpha = 1;
            UpgradeUi.GetComponent<CanvasGroup>().interactable = true;
            UpgradeUi.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        else
        {
            UpgradeUi.GetComponent<CanvasGroup>().alpha = 0;
            UpgradeUi.GetComponent<CanvasGroup>().interactable = false;
            UpgradeUi.GetComponent<CanvasGroup>().blocksRaycasts = false;
            FlipFlop = 0;
        }
    }
}
