using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Canvas canvas;
    public int numberOfDiamants = 10;
    bool gamePaused = false;
    public GameObject portal;

    private Dictionary<string, Stats> gameStats;



    private void Awake()
    {
        if (instance == null)
            instance = this;

        InitializeGameStats();
        DontDestroyOnLoad(instance);
    }

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

    public void PauseUnPauseGame(int time)
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



    private void InitializeGameStats()
    {
        gameStats = new Dictionary<string, Stats>();

        gameStats.Add("Level 1", new Stats());
        gameStats.Add("Level 2", new Stats());
        gameStats.Add("Level 3", new Stats());
        gameStats.Add("Boss", new Stats());

    }

    public void AddElementToStat(EElementType type, int quantity = 0)
    {
        Stats stats;
        if (gameStats.TryGetValue(SceneManager.GetActiveScene().name, out stats))
        {
            switch (type)
            {
                case EElementType.Diamant:
                    stats.Diamants++;
                    break;
                case EElementType.Enemy:
                    stats.Enemies++;
                    break;
                case EElementType.Lives:
                    stats.LivesRemain = quantity;
                    break;
                default:
                    break;
            }
        }

    }

    public void AddElementToStat(PowerUpItem item)
    {
        Stats stats;
        if (gameStats.TryGetValue(SceneManager.GetActiveScene().name, out stats))
        {
            stats.AddPowerUp(item);
        }
    }

    public Stats CurrentStats
    {
        get
        {
            gameStats.TryGetValue(SceneManager.GetActiveScene().name, out Stats stats);
            return stats;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

public enum EElementType
{
    Diamant,
    Enemy,
    Lives
}