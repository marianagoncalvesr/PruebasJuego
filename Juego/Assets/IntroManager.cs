using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    GameObject door;

    void Start()
    {
        door = GameObject.FindGameObjectWithTag("Door");
        door.GetComponent<DoorController>().StartKeys(true);




    }

    
}
