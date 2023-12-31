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

    private void Start()
    {
        AudioManager.instance.Play("Results Music");
    }
    
    public void BackPressed()
    {
        AudioManager.instance.Play("Button");
        SceneManager.LoadScene("MainMenu");
    }
}
