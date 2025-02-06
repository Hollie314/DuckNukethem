using TMPro;
using UnityEngine;

public class UI_Text : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI text;

    public void Sync(int coin)
    {
        text.text = coin.ToString();
    }
}
