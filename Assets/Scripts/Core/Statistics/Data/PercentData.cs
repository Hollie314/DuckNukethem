using UnityEngine;

namespace Core.Statistics
{
    [CreateAssetMenu(fileName = "Percent", menuName = "UpgradeFormulas/PercentData", order = 0)]
    public class PercentData : UpgradeFormulaData
    {
        [field: SerializeField] public int ValuePercent { get; private set; }
        public override int CalculateValue(int currentValue, int upgradeCount)
            => currentValue + Mathf.FloorToInt(currentValue * ValuePercent * 0.01f);
    }
}