using Game.Door;
using Game.Player;
using Game.Popups;
using General;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Mage _mage;
        [SerializeField] private Timer _timer;
        [SerializeField] private LockController _lock;
        [SerializeField] private WinPopup _winPopup;
        [SerializeField] private LosePopup _losePopup;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioSource _music;
        [Space] 
        [SerializeField] private AudioClip _winAudio;
        [SerializeField] private AudioClip _loseAudio;

        private GameStateType _gameState;
    
        private void Awake()
        {
            _timer.TimeEnded += OnTimerEnded;
            _lock.LockOpen += OnLockOpen;

            _winPopup.RestartClicked += OnRestart;
            _winPopup.MenuClicked += OnBackToMenu;
            _losePopup.RestartClicked += OnRestart;
            _losePopup.MenuClicked += OnBackToMenu;

            _gameState = GameStateType.InMenu;
        }

        private void Start()
        {
            FadeController.Instance.FadeOut(OnFadeOutCompleted);
        }

        private void OnFadeOutCompleted()
        {
            _music.Play();
            _gameState = GameStateType.InGame;
            _timer.Activate();
            _mage.Activate();
        }
    
        private void OnFadeInCompleted()
        {
            _music.Stop();
            _mage.Deactivate();
        
            if (_gameState == GameStateType.Won)
            {
                _audioSource.PlayOneShot(_winAudio);
                _winPopup.Open(_timer.TimePass);
            }
            else if(_gameState == GameStateType.Lost)
            {
                _audioSource.PlayOneShot(_loseAudio);
                _losePopup.Open();
            }
        }
    
        private void OnLockOpen()
        {
            if(_gameState != GameStateType.InGame) return;

            _gameState = GameStateType.Won;
            _timer.Stop();
        
            FadeController.Instance.FadeIn(OnFadeInCompleted);
        }

        private void OnTimerEnded()
        {
            if(_gameState != GameStateType.InGame) return;

            _gameState = GameStateType.Lost;
        
            FadeController.Instance.FadeIn(OnFadeInCompleted);
        }

        private void OnRestart()
        {
            SceneManager.LoadScene(1);
        }

        private void OnBackToMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}