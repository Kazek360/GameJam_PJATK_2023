using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;

    private void Awake()
    {
        PlayerEvents.OnScoreUpdate += UpdateScore;
    }
    
    private void OnDestroy()
    {
        PlayerEvents.OnScoreUpdate -= UpdateScore;
    }
    private void UpdateScore(int currentScore)
    {
        _score.text = $"{currentScore}";
    }
}
