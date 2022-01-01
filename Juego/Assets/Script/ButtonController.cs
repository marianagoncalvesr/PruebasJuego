using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] GameObject floor;
    Animator anim;
    [SerializeField] GameObject buttonBase;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        floor = GameObject.FindWithTag("MovingFloor");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            floor.GetComponent<MovingFloorController>().ButtomPress();
            anim.SetBool("Down", true);
            buttonBase.GetComponent<Renderer>().material.color = Color.green;
        }
        
    }

   

}
