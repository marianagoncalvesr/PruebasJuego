using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public enum scenes { Intro = 1, Level1, Level2,level3 }

public class PortalSwitch : MonoBehaviour
{

   
    [SerializeField] private scenes Change;
    [SerializeField] int kay = 0;
    [SerializeField] int diamonn = 0;
    [SerializeField] Transform particles;
    public bool PortalActivated = false;


    public PlayerController playerDiamond;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerDiamond = player.GetComponent<PlayerController>();
        if (PortalActivated)
            Instantiate(particles, transform);
    }



    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Portal Final"))
        {
            Scenes();

            GameObject gO = GameObject.FindGameObjectWithTag("Canvas");
            if (gO != null)
            {
                gO.GetComponent<CanvasController>().ActivateEndLevelStats();

            }


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
            case scenes.Level2:
                if (playerDiamond.diamonds == 20)
                    SceneManager.LoadScene("Level 2");
                break;
            case scenes.level3:
                SceneManager.LoadScene("Level 3");
                break;
            default:
                Debug.Log("No se puso una escena");
                break;

        }


    }

}
