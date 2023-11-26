using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    [SerializeField] private float _timeRemaining;
    private bool _isTimeRunning;
    [SerializeField] private TMP_Text _timerText;

    // Start is called before the first frame update
    void Start()
    {
        _isTimeRunning = true;
    }

    // Update is called once per frame
    void Update()
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
}
