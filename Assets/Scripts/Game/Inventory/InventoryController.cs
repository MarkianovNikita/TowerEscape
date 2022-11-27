using System;
using System.Collections.Generic;
using Items;
using UnityEngine;

namespace Inventory
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] private ItemsContainer _itemsContainer;
        [SerializeField] private InventoryView _inventoryView;
        [SerializeField] private Transform _itemDropZone;
        [SerializeField] private AudioSource _audioSource;
        [Space] 
        [SerializeField] private float _dropTorque;
        [SerializeField] private float _dropForce;

        private ItemData _itemDataInHands;
        private readonly List<ItemView> _closestItems = new List<ItemView>();

        public bool HasItem => _itemDataInHands != null;

        public void TryTakeClosestItem()
        {
            var itemToTake = GetClosestItem();
            if(itemToTake == null) return;
            
            RemoveCloseItem(itemToTake);
            TakeItem(itemToTake.Data);
            
            _audioSource.PlayOneShot(itemToTake.Data.PickupSound);
            
            _closestItems.Remove(itemToTake);
            
            Destroy(itemToTake.gameObject);
        }

        public ItemData ExtractItem()
        {
            if (!HasItem) return null;

            var itemToGive = _itemDataInHands;

            _itemDataInHands = null;
            _inventoryView.UpdateItem(null);

            return itemToGive;
        }
        
        private void TakeItem(ItemData itemData)
        {
            DropCurrentItem();

            _itemDataInHands = itemData;
            
            _inventoryView.UpdateItem(itemData);
        }

        private void DropCurrentItem()
        {
            if(_itemDataInHands == null) return;

            var itemPrefab = _itemsContainer.GetPrefab(_itemDataInHands);
            var droppedItemInstance = Instantiate(itemPrefab, _itemDropZone.position, Quaternion.identity);
            droppedItemInstance.GetComponent<Rigidbody>().AddForce(Vector3.up*_dropForce);
            droppedItemInstance.GetComponent<Rigidbody>().AddTorque(Vector3.one*_dropTorque);

            _itemDataInHands = null;
        }

        private ItemView GetClosestItem()
        {
            if (_closestItems.Count == 0) return null;
            
            var minDistance = float.MaxValue;
            ItemView closestItem = null;

            for (int i = 0; i < _closestItems.Count; i++)
            {
                var item = _closestItems[i];
                var distance = Vector3.Distance(transform.position, item.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestItem = item;
                }
            }

            return closestItem;
        }
        
        private void AddCloseItem(ItemView item)
        {
            _closestItems.Add(item);
            _inventoryView.AddClosestItem(item.Data);
        }

        private void RemoveCloseItem(ItemView item)
        {
            _closestItems.Remove(item);
            _inventoryView.RemoveClosestItem(item.Data);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            var itemView = other.GetComponent<ItemView>();
            if(itemView == null) return;

            AddCloseItem(itemView);
        }
        
        private void OnTriggerExit(Collider other)
        {
            var itemView = other.GetComponent<ItemView>();
            if(itemView == null) return;

            RemoveCloseItem(itemView);
        }
    }
}