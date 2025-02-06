using UnityEngine;

public class AutomateSystem : MonoBehaviour, IAffordable<int>
{

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Buy(ref int coin, int product)
    {
        return false;
    }
}
