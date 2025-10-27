using UnityEngine;

namespace Core.Statistics
{
    [CreateAssetMenu(fileName = "Exponential", menuName = "UpgradeFormulas/ExponentialData", order = 0)]
    public class ExponentialData : UpgradeFormulaData
    {
        [field: SerializeField] public int ValueBase { get; private set; } 

        public override int CalculateValue(int currentValue, int upgradeCount)
            => currentValue + (int)Mathf.Pow(ValueBase,upgradeCount);
    }
}