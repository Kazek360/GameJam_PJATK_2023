using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainView;
    [SerializeField] private GameObject _instructionsView;
    [SerializeField] private GameObject _creditsView;

    private void Awake()
    {
        _mainView.SetActive(true);
        _instructionsView.SetActive(false);
        _creditsView.SetActive(false);
    }

    #region  Main View
    public void StartClicked(string sceneName)
    {
        AudioManager.instance.Play("Button");
        SceneManager.LoadScene(sceneName);
    }

    public void InstructionsClicked()
    {
        AudioManager.instance.Play("Button");
        _mainView.SetActive(false);
        _instructionsView.SetActive(true);
    }

    public void CreditsClicked()
    {
        AudioManager.instance.Play("Button");
        _mainView.SetActive(false);
        _creditsView.SetActive(true);
    }

    public void ExitClicked()
    {
        AudioManager.instance.Play("Button");
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
    #endregion

    public void BackClicked()
    {
        AudioManager.instance.Play("Button");
        _mainView.SetActive(true);
        _instructionsView.SetActive(false);
        _creditsView.SetActive(false);
    }
}
