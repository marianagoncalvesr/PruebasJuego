using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    float timer;
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //if (timer > 4)
        //{
        //    SceneManager.LoadScene("MainMenu");
        //}

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
