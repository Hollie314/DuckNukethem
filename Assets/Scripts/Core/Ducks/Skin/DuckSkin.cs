using Core.Enum;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Ducks.Skin
{
    public class DuckSkin : MonoBehaviour
    {
        [field: SerializeField] public DuckType DuckType { get; private set; }
        [field: SerializeField] public Sprite SkinSprite { get; private set; }
        [field: SerializeField] public bool IsLocked { get; private set; }
        [field: SerializeField] public Image SkinIcon { get; private set; }
        [field: SerializeField] public AnimationClip walkAnimation { get; private set; }

        public void Unlock()
        {
            SkinIcon.sprite = SkinSprite;
            IsLocked = false;
        }

        public void Select()
        {
            SkinIcon.color = Color.white;
        }
        
        public void UnSelect()
        {
            SkinIcon.color = Color.grey;
        }
    }
}