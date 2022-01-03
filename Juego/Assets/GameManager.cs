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
        NewGame();
        DontDestroyOnLoad(instance);
    }

    public void NewGame()
    {
        InitializeKeys();
        InitializeGameStats();
    }
 

    private void InitializeKeys()
    {
        doorKeysTotal = new Keys[3];

        for (int i = 0; i < doorKeysTotal.Length; i++)
        {
            doorKeysTotal[i] = new Keys() { Lvl = i + 1, Picked = false, UsedInDoor = false };
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

    public int GetKeysPicked()
    {
        int keys = 0;
        Keys[] llaves = GameManager.instance.doorKeysTotal;
        for (int i = 0; i < llaves.Length; i++)
        {
            if (llaves[i].Picked == true)
            {
                keys++;
            }
        }
        return keys;
    }

    public Queue<Keys> GetKeysAvailable(bool used = false)
    {
        Queue<Keys> keysNotUsed = new Queue<Keys>();

        Keys[] llaves = GameManager.instance.doorKeysTotal;

        for (int i = 0; i < llaves.Length; i++)
        {
            if (llaves[i].Picked == true && llaves[i].UsedInDoor == used)
            {
                keysNotUsed.Enqueue(llaves[i]);
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