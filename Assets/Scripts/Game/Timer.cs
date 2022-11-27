using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public event Action TimeEnded;
    
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private Image _timerImage;
    [Space] 
    [SerializeField] private float _startTime;

    private float _timeLeft;
    private bool _isTimerDone;

    public float TimeLeft => _timeLeft;
    public float TimePass => _startTime - _timeLeft;
    
    public void Activate()
    {
        _isTimerDone = false;
        _timeLeft = _startTime;
        
        gameObject.SetActive(true);
    }

    public void Stop()
    {
        _isTimerDone = true;
    }
    
    private void Start()
    {
        _isTimerDone = true;
    }

    private void Update()
    {
        if(_isTimerDone) return;

        UpdateView(_timeLeft);

        _timeLeft -= Time.deltaTime;
        
        if (_timeLeft <= 0)
        {
            _timeLeft = 0;

            _isTimerDone = true;
            
            TimeEnded?.Invoke();
        }
    }

    private void UpdateView(float timeLeft)
    {
        _timerText.text = timeLeft.ToString("00");
        _timerImage.fillAmount = timeLeft / _startTime;
    }
}