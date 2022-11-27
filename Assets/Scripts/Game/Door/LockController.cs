using System;
using DefaultNamespace;
using Items;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Door
{
    public class LockController : MonoBehaviour
    {
        private static readonly int AnimationTriggerHashHappy = Animator.StringToHash("Happy");
        private static readonly int AnimationTriggerHashAngry = Animator.StringToHash("Angry");
        
        public event Action LockOpen;
        
        [SerializeField] private Transform _itemDropZone;
        [SerializeField] private ItemsContainer _itemsContainer;
        [SerializeField] private DoorController _door;
        [SerializeField] private float _dropForce;
        [SerializeField] private float _dropTorque;
        [SerializeField] private LockView _lockView;
        [SerializeField] private LockDialogView _dialogView;
        [SerializeField] private GameContext _gameContext;
        [Space] 
        [SerializeField] private AudioClip _successSound;
        [SerializeField] private AudioClip _failSound;

        private Order[] _orders;
        private int _currentTargetIndex;
        
        private Animator _animator;
        private AudioSource _audioSource;
        private ItemData _inputItem;

        private bool _completed;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            var amountOfItems = _gameContext.Difficulty;
            _orders = new Order[amountOfItems];
            for (var i = 0; i < amountOfItems; i++)
            {
                var randomItem = _itemsContainer.GetRandomItem();
                
                var types = Enum.GetValues(typeof(OrderType));
                var orderType = (OrderType)types.GetValue(Random.Range(0, types.Length));

                _orders[i] = new Order(orderType,randomItem);
            }
            _currentTargetIndex = 0;
        }

        public void GiveItem(ItemData itemData)
        {
            _inputItem = itemData;
            
            if (_orders[_currentTargetIndex].IsItemOkay(itemData))
            {
                _audioSource.PlayOneShot(_successSound);
                _animator.SetTrigger(AnimationTriggerHashHappy);
            }
            else
            {
                _audioSource.PlayOneShot(_failSound);
                _animator.SetTrigger(AnimationTriggerHashAngry);
            }
        }

        //Called from animation
        public void LockHappyComplete()
        {
            _currentTargetIndex++;

            if (_currentTargetIndex >= _orders.Length)
            {
                _door.Open();
                LockOpen?.Invoke();
                OnPlayerExit();

                _completed = true;
            }
            else
            {
                OnPlayerEntered();
            }
        }

        //Called from animation
        public void LockAngryDropItem()
        {
            var itemPrefab = _itemsContainer.GetPrefab(_inputItem);
            var itemInstance = Instantiate(itemPrefab, _itemDropZone.position, Quaternion.identity);
            
            itemInstance.GetComponent<Rigidbody>().AddForce(_itemDropZone.forward * _dropForce);
            itemInstance.GetComponent<Rigidbody>().AddTorque(Vector3.one * _dropTorque);
        }

        public void OnPlayerEntered()
        {
            if(_completed) return;
            
            _lockView.ShowText();
            _dialogView.Show(_orders[_currentTargetIndex].GetOrderText());
        }

        public void OnPlayerExit()
        {
            _lockView.HideText();
            _dialogView.Hide();
        }
    }
}