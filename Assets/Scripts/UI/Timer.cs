using System.Collections;
using System.Collections.Generic;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    [SerializeField] private float _timeRemaining;
    private bool _isTimeRunning;
    [SerializeField] private PlayerScore _playerScore;
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

        if (_timeRemaining <= 0)
        {
            PlayerPrefs.SetInt("Score",_playerScore.GetScore());
            SceneManager.LoadScene("ResultsScreen");
        }
        
    }

    private void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void IncreaseTime()
    {
        _timeRemaining += 15;
        float minutes = Mathf.FloorToInt(_timeRemaining / 60);
        float seconds = Mathf.FloorToInt(_timeRemaining % 60);
        _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
