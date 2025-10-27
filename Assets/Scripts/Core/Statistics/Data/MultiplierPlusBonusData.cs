using UnityEngine;

namespace Core.Statistics
{
    [CreateAssetMenu(fileName = "MultiplierPlusBonus", menuName = "UpgradeFormulas/MultiplierPlusBonusData", order = 0)]
    public class MultiplierPlusBonusData : UpgradeFormulaData
    {
        [field: SerializeField] public int ValueMultiplier { get; private set; } 
        [field: SerializeField] public int ValueBonus { get; private set; } 

        public override int CalculateValue(int currentValue, int upgradeCount)
            => currentValue * ValueMultiplier + ValueBonus;
    }
}