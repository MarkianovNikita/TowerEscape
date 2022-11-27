using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenu
{
    public class PlayWindow : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _closeButton;
        [SerializeField] private Slider _slider;
        [SerializeField] private GameContext _gameContext;

        private void Awake()
        {
            _playButton.onClick.AddListener(OnPlayClicked);
            _closeButton.onClick.AddListener(Close);
            _slider.onValueChanged.AddListener(OnValueChanged);
        }

        public void OnValueChanged(float value)
        {
            _gameContext.Difficulty = (int)value;
        }
        

        public void Open()
        {
            _slider.value = _gameContext.Difficulty;
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
        
        private void OnPlayClicked()
        {
            SceneManager.LoadScene(1);
        }
    }
}