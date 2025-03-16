using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public GameObject titleScreen;

    public GameObject settingsScreen;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    public void StartGame() // oyunu başlat
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OpenSettings() // ana menüden ayarlar ekranına geç
    {
        titleScreen.SetActive(false);
        settingsScreen.SetActive(true);
    }
    
    public void CloseSettings() // ayarlar ekranından ana menüye dönme
    {
        titleScreen.SetActive(true);
        settingsScreen.SetActive(false);
    }

    public void QuitGame() // oyunu kapat
    {
        Application.Quit();
    }
}
