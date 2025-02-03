using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource audio;

    public void Clicked()
    {
        audio.Play();
    }
}
