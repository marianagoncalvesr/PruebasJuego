using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    private bool gamePaused;
    [SerializeField] GameObject pauseMenu;

    private void Start()
    {
        gamePaused = false;
        pauseMenu.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!gamePaused)
                PauseUnPauseGame();
            else
                PauseUnPauseGame();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            PauseUnPauseGame();

    }

    public void PauseUnPauseGame()
    {
        gamePaused = !gamePaused;
        pauseMenu.SetActive(gamePaused);
        if (gamePaused) Time.timeScale = 0; else Time.timeScale = 1;
        
    }

    public void GoToMainMenu()
    {
        PauseUnPauseGame();
        GameManager.instance.CleanKeysPicked();
        SceneManager.LoadScene("MainMenu");
    }

    public void LeaveLevel()
    {
        PauseUnPauseGame();
        GameManager.instance.CleanKeysPicked();
        SceneManager.LoadScene("Intro");
    }




}
