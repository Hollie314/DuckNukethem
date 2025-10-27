using UnityEngine;

namespace Core.Statistics
{
    public abstract class UpgradeFormulaData : ScriptableObject
    {
        public abstract int CalculateValue(int currentValue, int upgradeCount);
    }
}