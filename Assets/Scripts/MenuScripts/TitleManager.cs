using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject buffsScreen;
    public GameObject settingsScreen;

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OpenBuffsScreen()
    {
        titleScreen.SetActive(false);
        buffsScreen.SetActive(true);
    }

    public void OpenSettings()
    {
        titleScreen.SetActive(false);
        settingsScreen.SetActive(true);
    }
    
    public void OpenMainMenu()
    {
        titleScreen.SetActive(true);
        buffsScreen.SetActive(false);
        settingsScreen.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
