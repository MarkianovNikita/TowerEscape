using System.Collections.Generic;
using Game.Items;
using General.Localization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Inventory
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _itemName;
        [SerializeField] private Image _icon;

        [SerializeField] private ClosestItemSlotView _slotTemplate;

        private List<ClosestItemSlotView> _closestItemSlots;

        private void Awake()
        {
            _closestItemSlots = new List<ClosestItemSlotView>();

            _slotTemplate.gameObject.SetActive(false);
            
            ClearView();
        }

        public void UpdateItem(ItemData itemData)
        {
            if (itemData == null)
            {
                ClearView();
            }
            else
            {
                _itemName.text = itemData.Name;
                _icon.sprite = itemData.Icon;
                _icon.transform.parent.gameObject.SetActive(true);
            }
        }

        public void AddClosestItem(ItemData item)
        {
            var slotInstance = Instantiate(_slotTemplate, _slotTemplate.transform.parent);
            slotInstance.Init(item);
            slotInstance.gameObject.SetActive(true);
            
            _closestItemSlots.Add(slotInstance);
        }

        public void RemoveClosestItem(ItemData item)
        {
            var slot = _closestItemSlots.Find(x => x.Item == item);
            if (slot != null)
            {
                _closestItemSlots.Remove(slot);
                Destroy(slot.gameObject);
            }
        }

        private void ClearView()
        {
            _itemName.text = string.Empty;
            _icon.transform.parent.gameObject.SetActive(false);
        }
    }
}