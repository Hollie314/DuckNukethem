using UnityEngine;

public class UI_Locker : MonoBehaviour
{
    [field: SerializeField]
    private GameObject locker;
    [field: SerializeField]
    private GameObject[] products;
    [field: SerializeField]
    private int price;
    
    
    public GameObject Locker => locker;
    public GameObject[] Locks => products;
    public int Price => price;
    
    public void Unlock()
    {
        foreach (var product in products)
        {
            product.SetActive(true);
        }
        locker.SetActive(false);
    }
}
