using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Popups
{
    public class WinPopup : PopupBase
    {
        public event Action RestartClicked;
        
        [SerializeField] private Button _restartButton;
        [SerializeField] private TMP_Text _timeLeftText;

        protected override void Awake()
        {
            base.Awake();
            _restartButton.onClick.AddListener(OnRestartClicked);
        }

        public void Open(float timePass)
        {
            _timeLeftText.text = $"{timePass:00} seconds";
            Open();
        }
        
        private void OnRestartClicked()
        {
            AudioSource.Play();
            RestartClicked?.Invoke();
        }
    }
}