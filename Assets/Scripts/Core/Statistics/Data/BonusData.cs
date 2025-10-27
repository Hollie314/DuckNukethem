using UnityEngine;

namespace Core.Statistics
{
    [CreateAssetMenu(fileName = "Bonus", menuName = "UpgradeFormulas/BonusData", order = 0)]
    public class BonusData : UpgradeFormulaData
    {
        [field: SerializeField] public int ValueBonus { get; private set; } 

        public override int CalculateValue(int currentValue, int upgradeCount)
            => currentValue + ValueBonus;
    }
}