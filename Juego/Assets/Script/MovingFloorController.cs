using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloorController : MonoBehaviour
{
    [SerializeField] private int buttomPress = 0;

    Animator anim;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void ButtomPress()
    {
        buttomPress += 1;
    }

    void Movement()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
            if (buttomPress == 2)
                anim.SetBool("Up", true);

        if (other.gameObject == player)
        {
            player.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.parent = null; 
        }

    }




}
