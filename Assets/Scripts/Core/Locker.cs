using UnityEngine;

public class Locker : MonoBehaviour
{
    [field: SerializeField]
    private GameObject product;
    [field: SerializeField]
    private GameObject _lock;
    [field: SerializeField]
    private int price;
    
    
    public GameObject Product => product;
    public GameObject Lock => _lock;
    public int Price => price;
}
