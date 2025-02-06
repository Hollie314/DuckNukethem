using UnityEngine;

[CreateAssetMenu(fileName = "DuckData", menuName = "Scriptable Objects/DuckData")]
public class DuckData : ScriptableObject
{
    [field: SerializeField]
    public int cost { get; private set; }
    [field: SerializeField]
    public int damage { get; private set; }
    [field: SerializeField]
    public int coingain { get; private set; }
    [field: SerializeField]
    public float speed { get; private set; }
    
    [field: SerializeField]
    public Duck_ duck_prefab { get; private set; }
}
