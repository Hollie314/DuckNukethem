using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource classic;
    public AudioSource no_coin;

      
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
}
