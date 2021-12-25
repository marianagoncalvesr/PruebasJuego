using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomController : MonoBehaviour
{
    GameObject player;
    GameObject cannon;
   

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        cannon = GameObject.FindWithTag("Cannon");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(player)
        {
            Debug.Log("Player colisionando");
            cannon.GetComponent<CannonController>().DestroyCannon();
        }
    }

}
