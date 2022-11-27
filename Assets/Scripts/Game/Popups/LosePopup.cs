using System;
using UnityEngine;
using UnityEngine.UI;

namespace Popups
{
    public class LosePopup : PopupBase
    {
        public event Action RestartClicked;
        
        [SerializeField] private Button _restartButton;

        protected override void Awake()
        {
            base.Awake();
            _restartButton.onClick.AddListener(OnRestartClicked);
        }

        private void OnRestartClicked()
        {
            AudioSource.Play();
            RestartClicked?.Invoke();
        }
    }
}