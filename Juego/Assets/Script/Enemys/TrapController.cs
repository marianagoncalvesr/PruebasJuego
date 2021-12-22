using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrapController : MonoBehaviour
{
    Animator anim;
    [SerializeField] private float timer = 0.0f;

    GameObject player;
    PlayerController playerScript;

    // Start is called before the first frame update
    void Start()
    {
        
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        OpenTrap();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Colissionando");
            anim.SetBool("Close", true);
            timer = 0;

            player.GetComponent<PlayerController>().CambiarEstado();

        }

    }

    private void OpenTrap()
    {
        if (timer > 3)
        {
            anim.SetBool("Close", false);
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        anim.SetBool("Close", false);
            
    //    }
    //}
}
