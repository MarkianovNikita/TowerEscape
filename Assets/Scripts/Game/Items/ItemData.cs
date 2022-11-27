using UnityEngine;

namespace Game.Items
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "Data/Create ItemData")]
    public class ItemData : ScriptableObject
    {
        public string Name;
        public string Article;
        public ColorType Color;
        public ItemType Type;
        public Sprite Icon;
        public AudioClip PickupSound;
    }

    public enum ColorType
    {
        White,
        Green,
        Blue,
        Red,
        Purple,
        Yellow,
        Black
    }

    public enum ItemType
    {
        Key,
        Crown,
        Mushroom,
        Potion,
        Meat
    }
}