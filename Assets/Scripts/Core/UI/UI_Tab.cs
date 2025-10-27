using UnityEngine;

public class UI_Tab : MonoBehaviour
{
    private bool window_opened = false;
    [field : SerializeField] public GameObject UITab { get; private set; }
    
    public void OpenTab()
    {
        UITab.SetActive(!window_opened);
        window_opened = !window_opened;
    }
}
