using Core.Enum;
using TMPro;
using UnityEngine;

namespace Core.UI
{
    public class UI_Statistique : MonoBehaviour
    {
        [field : SerializeField] 
        private TextMeshProUGUI text;
        [field : SerializeField] 
        private TextMeshProUGUI costText;
        [field : SerializeField] public DuckType DuckType { get; private set; }
        [field : SerializeField] public StatType StatType { get; private set; }
        
        public void Sync(int value, int cost)
        {
            text.text = value.ToString();
            costText.text = cost.ToString();
        }

        public bool DoesItMatch(DuckType duckType, StatType statType)
        {
            return DuckType == duckType && StatType == statType;
        }
    }
}