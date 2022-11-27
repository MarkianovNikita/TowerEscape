using System;
using General;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Popups
{
    public class PopupBase : MonoBehaviour
    {
        public event Action RestartClicked;
        public event Action MenuClicked;
        
        [SerializeField] private Button _backToMenuButton;
        [SerializeField] private Button _restartButton;
        
        private Animator _animator;
        private static readonly int AnimationTriggerHashOpen = Animator.StringToHash("Open");

        protected virtual void Awake()
        {
            _animator = GetComponent<Animator>();
            
            _backToMenuButton.onClick.AddListener(OnBackToMenuClicked);
            _restartButton.onClick.AddListener(OnRestartClicked);
        }

        public void Open()
        {
            gameObject.SetActive(true);
            _restartButton.Select();
        }

        public void Close()
        {
            _animator.SetTrigger(AnimationTriggerHashOpen);
        }
        
        private void OnBackToMenuClicked()
        {
            UiSoundsManager.Instance.PlayClickSound();
            MenuClicked?.Invoke();
        }
        
        private void OnRestartClicked()
        {
            UiSoundsManager.Instance.PlayClickSound();
            RestartClicked?.Invoke();
        }
    }
}