using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    GameObject door;
    [SerializeField] GameObject portal2;
    [SerializeField] GameObject portal3;
    void Start()
    {
        DiamondController.cantidadDiamantes = 0;
        door = GameObject.FindGameObjectWithTag("Door");
        door.GetComponent<DoorController>().StartKeys(true);
        EnablePortals();
    }

    public void EnablePortals()
    {
        if (GameManager.instance.GetKeysPicked() >= 2)
        {
            portal2.SetActive(true);
            portal3.SetActive(true);
        }
        else if (GameManager.instance.GetKeysPicked() == 1)
        {
            portal2.SetActive(true);
        }


    }
}
