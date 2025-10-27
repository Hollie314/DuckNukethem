using Core.Enum;
using UnityEngine;

namespace Core.Ducks.Skin
{
    public class DuckSkin : MonoBehaviour
    {
        [field: SerializeField] public DuckType DuckType { get; private set; }
        [field: SerializeField] public Sprite SkinSprite { get; private set; }
        [field: SerializeField] public bool IsLocked { get; private set; }
        [field: SerializeField] public Sprite UnlockSprite { get; private set; }
        [field: SerializeField] public SpriteRenderer SkinIcon { get; private set; }

        public void Unlock()
        {
            SkinIcon.sprite = UnlockSprite;
            IsLocked = false;
        }

        public void Select()
        {
            
        }
        
        public void UnSelect()
        {
            
        }
    }
}