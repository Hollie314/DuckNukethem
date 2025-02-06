using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource classic;
    public AudioSource no_coin;
    public AudioSource audio_base;
      
    private void OnEnable()
    {
        GameManager.Instance.OnMoneySpentCoin += AudioButtonOk;
        GameManager.Instance.OnNotEnoughMoney += NotEnoughMoneySound;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnMoneySpentCoin -= AudioButtonOk;
        GameManager.Instance.OnNotEnoughMoney -= NotEnoughMoneySound;
    }
    
    public void AudioButtonOk()
    {
        classic.Play();
    }
    
    
    public void NotEnoughMoneySound()
    {
        no_coin.Play();
    }

    public void BasePlayAudio()
    {
      audio_base.Play();
    }
}
