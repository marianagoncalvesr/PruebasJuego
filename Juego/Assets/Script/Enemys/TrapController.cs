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
    GameObject tail;
    private int damage = 1;

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

        if (damage == 0)
            Destroy();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            anim.SetBool("Close", true);
            timer = 0;

            player.GetComponent<PlayerController>().Stunear();
            player.GetComponent<PlayerController>().Damage();

        }

        if (other.gameObject.CompareTag("TailHitBox"))
        {
            Debug.Log("Cola golpeando");
            damage = 0;
        }

    }


    private void OpenTrap()
    {
        if (timer > 3)
        {
            anim.SetBool("Close", false);
        }
    }

    private void Destroy()
    {
        Vector3 temp;

        temp = transform.localScale;
        temp.y -= 0.25f;
        transform.localScale = temp;

        if (temp.y == 0)
        {
            Destroy(this.gameObject);
        }
    }

}
