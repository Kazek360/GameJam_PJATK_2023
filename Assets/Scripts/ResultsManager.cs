using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultsManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private void Awake()
    {
        _text.text = PlayerPrefs.GetInt("Score").ToString();
    }
    
    public void BackPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
