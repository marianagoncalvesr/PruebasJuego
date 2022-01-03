using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int numberOfDiamants = 10;
    public bool gamePaused = false;

    Dictionary<string, Stats> gameStats;
    Keys[] doorKeysTotal;   // ya se pusieron en la puerta
    public Keys[] DoorKeysTotal { get => doorKeysTotal; }

    private void Awake()
    {
        if (instance == null)
            instance = this;

        InitializeKeys();
        InitializeGameStats();
        DontDestroyOnLoad(instance);
    }

    private void InitializeKeys()
    {
        doorKeysTotal = new Keys[3];

        for (int i = 0; i < doorKeysTotal.Length; i++)
        {
            doorKeysTotal[i] = new Keys() { Lvl = i + 1, Picked = true, UsedInDoor = false };
        }

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
        Debug.Log(CurrentStats.ToString());
    }


    public void GoToIntro()
    {
        SceneManager.LoadScene("intro");
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

    public void KeyPicked(int lvl)
    {
        for (int i = 0; i < doorKeysTotal.Length; i++)
        {
            if (doorKeysTotal[i].Lvl == lvl)
            {
                doorKeysTotal[i].Picked = true;
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



    public List<Keys> GetKeysAvailable()
    {
        List<Keys> keysNotUsed = new List<Keys>();

        Keys[] llaves = GameManager.instance.doorKeysTotal;

        for (int i = 1; i < llaves.Length + 1; i++)
        {
            if (llaves[i].Picked == true && llaves[i].Lvl == i && !llaves[i].UsedInDoor)
            {
                keysNotUsed.Add(llaves[i]);
            }
        }
        return keysNotUsed;

    }

}

public enum EElementType
{
    Diamant,
    Enemy,
    Lives
}