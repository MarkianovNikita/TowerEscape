using Game.Items;
using General.Localization;
using UnityEngine;

namespace Game.Door
{
    public class Order
    {
        public readonly OrderType Type;
        public readonly ItemData ItemData;

        public Order(OrderType orderType, ItemData item)
        {
            Type = orderType;
            ItemData = item;
        }

        public string GetOrderText()
        {
            switch (Type)
            {
                case OrderType.Item:
                    return string.Format(
                        LocalizationController.Instance.GetText("game_order_request_item_format"),
                        ItemData.NameInSentence
                        );
                case OrderType.Color:
                    return string.Format(
                        LocalizationController.Instance.GetText("game_order_request_color_format"),
                        LocalizationController.Instance.GetText(GetColorLocalizationKey(ItemData.Color))
                    );
                case OrderType.Type:
                    return string.Format(
                        LocalizationController.Instance.GetText("game_order_request_type_format"),
                        LocalizationController.Instance.GetText(GetTypeLocalizationKey(ItemData.Type))
                    );
                default:
                    Debug.LogError("Order type is wrong");
                    return "[ORDER]";
            }
        }

        public bool IsItemOkay(ItemData item)
        {
            switch (Type)
            {
                case OrderType.Item:
                    return item == ItemData;
                case OrderType.Color:
                    return item.Color == ItemData.Color;
                case OrderType.Type:
                    return item.Type == ItemData.Type;
                default:
                    Debug.LogError("Order type is wrong");
                    return false;
            }
        }
        
        
        private string GetColorLocalizationKey(ColorType color)
        {
            switch (color)
            {
                case ColorType.Red:
                    return "game_order_item_color_red";
                case ColorType.Blue:
                    return "game_order_item_color_blue";
                case ColorType.Green:
                    return "game_order_item_color_green";
                case ColorType.White:
                    return "game_order_item_color_white";
                case ColorType.Black:
                    return "game_order_item_color_black";
                case ColorType.Yellow:
                    return "game_order_item_color_yellow";
                case ColorType.Purple:
                    return "game_order_item_color_purple";
                default:
                    Debug.LogError("Color type doesn't have localization!");
                    return "[COLOR]";
            }
        }

        private string GetTypeLocalizationKey(ItemType type)
        {
            switch (type)
            {
                case ItemType.Key:
                    return "game_order_item_type_key";
                case ItemType.Meat:
                    return "game_order_item_type_meat";
                case ItemType.Crown:
                    return "game_order_item_type_crown";
                case ItemType.Potion:
                    return "game_order_item_type_potion";
                case ItemType.Mushroom:
                    return "game_order_item_type_mushroom";
                default:
                    Debug.LogError("Item type doesn't have localization!");
                    return "[TYPE]";
            }
        }
    }
    
    public enum OrderType
    {
        Item,
        Color,
        Type
    }
}