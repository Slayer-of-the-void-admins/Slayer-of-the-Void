using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject pauseScreen;
    public MapScript mapScript;

    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1f)
            {
                PauseGame();
            }
            else if (pauseScreen.activeSelf == true)
            {
                UnpauseGame();
            }
            else if (mapScript.mapPanel.activeSelf == true)
            {
                mapScript.CloseMap();
            }
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseGame()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
    }
    
    public void UnpauseGame()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }
}
