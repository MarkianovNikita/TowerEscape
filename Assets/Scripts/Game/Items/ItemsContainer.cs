using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Items
{
    public class ItemsContainer : MonoBehaviour
    {
        [SerializeField] private ItemView[] _prefabs;

        private List<ItemData> _items;

        public IReadOnlyList<ItemData> Items => _items;

        private void Awake()
        {
            _items = new List<ItemData>(_prefabs.Length);
            for (var i = 0; i < _prefabs.Length; i++)
            {
                var itemViewPrefab = _prefabs[i];
                _items.Add(itemViewPrefab.Data);
            }
        }

        public ItemView GetPrefab(ItemData itemData)
        {
            for (int i = 0; i < _prefabs.Length; i++)
            {
                if (_prefabs[i].Data == itemData) return _prefabs[i];
            }

            Debug.LogError("Can't find prefab for item!");
            return null;
        }

        public ItemData GetRandomItem()
        {
            var randIndex = Random.Range(0, Items.Count);

            return Items[randIndex];
        }
    }
}