using UnityEngine;

namespace Core.Statistics
{
    [CreateAssetMenu(fileName = "Multiplier", menuName = "UpgradeFormulas/MultiplierData", order = 0)]
    public class MultiplierData : UpgradeFormulaData
    {
        [field: SerializeField] public int ValueMultiplier { get; private set; } 

        public override int CalculateValue(int currentValue, int upgradeCount)
            => currentValue * ValueMultiplier;
    }
}