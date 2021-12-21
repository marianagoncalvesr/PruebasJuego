using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void QuitApp()
    {
        Application.Quit();
    }

    public void SceneLoad(string name)
    {
        SceneManager.LoadScene(name);
    }

}
