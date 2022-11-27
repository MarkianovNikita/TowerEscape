using System;
using General;
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
            UiSoundsManager.Instance.PlayClickSound();
            _gameContext.Difficulty = (int)value;
        }
        

        public void Open()
        {
            _slider.value = _gameContext.Difficulty;
            gameObject.SetActive(true);
        }

        public void Close()
        {
            UiSoundsManager.Instance.PlayClickSound();
            gameObject.SetActive(false);
        }
        
        private void OnPlayClicked()
        {
            UiSoundsManager.Instance.PlayClickSound();
            FadeController.Instance.FadeIn(() => SceneManager.LoadScene(1));
        }
    }
}