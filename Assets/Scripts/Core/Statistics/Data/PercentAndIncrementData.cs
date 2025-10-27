using UnityEngine;

namespace Core.Statistics
{
    [CreateAssetMenu(fileName = "PercentAndIncrement", menuName = "UpgradeFormulas/PercentAndIncrementData", order = 0)]
    public class PercentAndIncrementData : UpgradeFormulaData
    {
        [field: SerializeField] public int ValuePercent { get; private set; }
        public override int CalculateValue(int currentValue, int upgradeCount)
            => currentValue + Mathf.FloorToInt(currentValue *(upgradeCount + 1)* ValuePercent * 0.01f);
    }
}