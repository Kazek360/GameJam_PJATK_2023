using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    [SerializeField] private float _timeRemaining;
    private bool _isTimeRunning;
    [SerializeField] private TMP_Text _timerText;


    private void Awake()
    {
        PlayerEvents.OnOrderComplete += IncreaseTime;
    }
    private void Start()
    {
        _isTimeRunning = true;
    }

    private void OnDestroy()
    {
        PlayerEvents.OnOrderComplete -= IncreaseTime;
    }

    private void Update()
    {
        if(_isTimeRunning)
        {
            if (_timerText != null)
            {
                _timeRemaining -= Time.deltaTime;
                DisplayTime(_timeRemaining);
            }
        }
    }

    private void DisplayTime(float timeToDisplay)
    {
        timeToDisplay -= 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void IncreaseTime()
    {
        _timeRemaining += 10;
        float minutes = Mathf.FloorToInt(_timeRemaining / 60);
        float seconds = Mathf.FloorToInt(_timeRemaining % 60);
        _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}