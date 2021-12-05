using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Canvas canvas;
    public int numberOfDiamants = 10;
    bool gamePaused = false;
    public GameObject portal;


    private void Awake()
    {
        if (instance == null)
            instance = this;

        DontDestroyOnLoad(instance);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!gamePaused)
                PauseUnPauseGame(0);
            else
                PauseUnPauseGame(1);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            PauseUnPauseGame(1);

    }

    private void PauseUnPauseGame(int time)
    {
        gamePaused = !gamePaused;
        Time.timeScale = time;
    }

    public void CompleteLevel()
    {
        

    }
    
    public void ActivatePortal()
    {
        portal.SetActive(true);
    }
    



}
