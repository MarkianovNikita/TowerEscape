using System;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _infoButton;
        [SerializeField] private Button _exitButton;

        [SerializeField] private InfoWindow _infoWindow;
        [SerializeField] private PlayWindow _playWindow;

        private void Awake()
        {
            _playButton.onClick.AddListener(OnPlayClicked);
            _infoButton.onClick.AddListener(OnInfoClicked);
            _exitButton.onClick.AddListener(OnExitClicked);
        }

        private void OnExitClicked()
        {
            Application.Quit();
        }

        private void OnInfoClicked()
        {
            _infoWindow.Open();
        }

        private void OnPlayClicked()
        {
            _playWindow.Open();
        }
    }
}