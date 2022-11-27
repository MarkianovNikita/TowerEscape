using System;
using DefaultNamespace;
using Door;
using Fade;
using Player;
using Popups;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Mage _mage;
    [SerializeField] private Timer _timer;
    [SerializeField] private LockController _lock;
    [SerializeField] private FadeController _fadeController;
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
        _fadeController.FadeOutCompleted += OnFadeOutCompleted;
        _fadeController.FadeInCompleted += OnFadeInCompleted;

        _winPopup.RestartClicked += OnRestart;
        _losePopup.RestartClicked += OnRestart;

        _gameState = GameStateType.InMenu;
    }

    private void Start()
    {
        _fadeController.FadeOut();
        _music.Play();
    }

    private void OnFadeOutCompleted()
    {
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
        
        _fadeController.FadeIn();
    }

    private void OnTimerEnded()
    {
        if(_gameState != GameStateType.InGame) return;

        _gameState = GameStateType.Lost;
        
        _fadeController.FadeIn();
    }

    private void OnRestart()
    {
        SceneManager.LoadScene(1);
    }
}