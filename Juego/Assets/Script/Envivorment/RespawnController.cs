using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    [SerializeField] GameObject respawn;
    //[SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        respawn = GameObject.FindWithTag("StartPosition");
        //player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Contacto");
            respawn.transform.position = transform.position;
            Destroy(this.gameObject);
        }
    }
}
