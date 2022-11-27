using System;
using General;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenu
{
    public class PlayWindow : MonoBehaviour
    {
        public event Action WindowClosed;
        
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
            UiSoundsManager.Instance.PlayClickSound();
            _gameContext.Difficulty = (int)value;
        }
        

        public void Open()
        {
            _slider.value = _gameContext.Difficulty;
            gameObject.SetActive(true);
            
            _playButton.Select();
        }

        public void Close()
        {
            UiSoundsManager.Instance.PlayClickSound();
            gameObject.SetActive(false);
            
            WindowClosed?.Invoke();
        }
        
        private void OnPlayClicked()
        {
            UiSoundsManager.Instance.PlayClickSound();
            FadeController.Instance.FadeIn(() => SceneManager.LoadScene(1));
        }
    }
}