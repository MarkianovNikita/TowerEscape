using Game.Items;
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
                    return $"Bring me {ItemData.Article} {ItemData.Name}";
                case OrderType.Color:
                    return $"I want something {ItemData.Color}";
                case OrderType.Type:
                    return $"Bring me any {ItemData.Type}";
                default:
                    Debug.LogError("Order type is wrong");
                    return "I don't know what I want!!!";
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
    }

    public enum OrderType
    {
        Item,
        Color,
        Type
    }
}