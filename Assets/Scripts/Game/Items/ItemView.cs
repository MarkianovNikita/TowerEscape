using UnityEngine;
using UnityEngine.Serialization;

namespace Items
{
    public class ItemView : MonoBehaviour
    {
        [SerializeField] private ItemData _data;

        public ItemData Data => _data;
    }
}