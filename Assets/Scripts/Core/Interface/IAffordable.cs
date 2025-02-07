using UnityEngine;

public interface IAffordable<T>
{
    bool Buy(ref int coin, T product);
}
