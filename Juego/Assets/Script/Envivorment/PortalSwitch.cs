using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PortalSwitch : MonoBehaviour
{

    enum scenes {Intro = 1, Level1, LevelBoss1, Level2}
    [SerializeField] private scenes Change;
    [SerializeField] int kay = 0;
    [SerializeField] int diamonn = 0;

    public PlayerController playerDiamond;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerDiamond = player.GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Scenes();
        }
    }
    void Scenes()
    {
        switch (Change)
        {
            case scenes.Intro:
                if (kay == 1)
                    SceneManager.LoadScene("Intro");
                break;            
            case scenes.Level1:
                SceneManager.LoadScene("Level 1");
                break;
            case scenes.LevelBoss1:
                if (playerDiamond.diamonds == 20)
                    SceneManager.LoadScene("Level 1 Boss");
                break;
            case scenes.Level2:
                    SceneManager.LoadScene("Level 2");
                break;
            default:              
                Debug.Log("No se puso una escena");
                break;

        }


    }

}
