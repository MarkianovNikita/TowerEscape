using General.Localization;
using UnityEngine;

namespace Game.Items
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "Data/Create ItemData")]
    public class ItemData : ScriptableObject
    {
        [SerializeField] private string _name;
        public string Name => LocalizationController.Instance.GetText($"game_item_name_{_name}");
        public string NameInSentence => LocalizationController.Instance.GetText($"game_item_name_in_sentence_{_name}");
        
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