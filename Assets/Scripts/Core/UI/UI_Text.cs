using TMPro;
using UnityEngine;

public class UI_Text : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI text;

    public void Sync(int value)
    {
        text.text = value.ToString();
    }
}
