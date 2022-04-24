using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameControler : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject gameButtons;
    public GameObject pauseMenu;
    public GameObject leftButton;
    public GameObject rightButton;
    public GameObject gameOverText;
    public static bool GameIsPause = (false);


    private void Start() 
    {
        gameOverPanel.SetActive(false);
        pauseMenu.SetActive(false);
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        gameButtons.SetActive(false);
        rightButton.SetActive(false);
        leftButton.SetActive(false);
        gameOverText.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
        GameIsPause = false;

    }

    public void QuiteGame()
    {
        Application.Quit(); 
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        gameOverPanel.SetActive(true);
        gameOverText.SetActive(false);
        gameButtons.SetActive(false);
        rightButton.SetActive(false);
        leftButton.SetActive(false);
        Time.timeScale = 0f;
        GameIsPause = true;
    }
    
    public void Resume()
    {
        pauseMenu.SetActive(false);
        gameOverPanel.SetActive(false);
        gameButtons.SetActive(true);
        rightButton.SetActive(true);
        leftButton.SetActive(true);
        Time.timeScale = 1f;
        GameIsPause = false;
    }
}    
