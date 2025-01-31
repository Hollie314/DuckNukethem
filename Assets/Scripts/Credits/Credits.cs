using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public void Credit(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void BackCredits(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
