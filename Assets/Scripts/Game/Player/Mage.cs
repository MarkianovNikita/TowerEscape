using Door;
using Inventory;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class Mage : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private AudioSource _audioSource;

        private InputActions _inputActions;
        private Rigidbody _rb;
        private Animator _animator;

        private InventoryController _inventory;

        private Vector2 _moveInput;

        private LockController _lock;

        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }
        
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();

            _inventory = GetComponent<Inventory.InventoryController>();
        
            _inputActions = new InputActions();

            _inputActions.Mage.Interact.performed += OnInteractClicked;
        }

        private void OnInteractClicked(InputAction.CallbackContext obj)
        {
            if (_inventory.HasItem && _lock != null)
            {
                var item = _inventory.ExtractItem();
                _lock.GiveItem(item);
            }
            else
            {
                _inventory.TryTakeClosestItem();
            }
        }

        private void OnEnable()
        {
            _inputActions.Mage.Enable();
        }

        private void OnDisable()
        {
            _inputActions.Mage.Disable();
        }

        private void Update()
        {
            _moveInput = _inputActions.Mage.Move.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            var inputForce = _moveInput.magnitude;

            var velocity = _rb.velocity;
            velocity.y = 0;

            velocity = transform.forward * (_moveSpeed * inputForce);

            _rb.velocity = velocity;

            var rotDirection =
                Vector3.SignedAngle(transform.forward, new Vector3(_moveInput.x, 0, _moveInput.y), Vector3.up);

            transform.Rotate(Vector3.up, _rotateSpeed * rotDirection * Time.fixedDeltaTime);


            var isMoving = inputForce > 0;
            _animator.SetBool("Run", isMoving);

            if (isMoving)
            {
                _audioSource.pitch = Random.Range(0.5f, 1f);
                if(!_audioSource.isPlaying) _audioSource.Play();
            }
            else if (_audioSource.isPlaying)
            {
                _audioSource.Stop();
            }
        }
    
        private void OnTriggerEnter(Collider other)
        {
            var lockController = other.GetComponent<LockController>();
            if(lockController == null) return;

            _lock = lockController;
            _lock.OnPlayerEntered();
        }
        
        private void OnTriggerExit(Collider other)
        {
            var lockController = other.GetComponent<LockController>();
            if(lockController == null) return;
        
            lockController.OnPlayerExit();
            _lock = null;
        }
    }
}