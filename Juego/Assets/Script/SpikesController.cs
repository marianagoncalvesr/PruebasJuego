using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesController : MonoBehaviour
{
    Animator anim;
    [SerializeField] private float timer = 0.0f;
    GameObject player;

    [SerializeField] private float tap = 0f;
    enum spikes { Spikes1 = 1, Spikes2, Spikes3 }
    [SerializeField] private spikes Change;
    [SerializeField] int waitTime = 2;
    [SerializeField] int maxTime = 4;




   


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
        Type();
    }

    private void SpikesMovement1()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            tap += 1;

        }
        if (tap == 1)
        {
            anim.SetBool("Up", true);
        }
        if (tap == 2)
        {
            anim.SetBool("Up", false);
            tap = 0;
        }

    }
    private void SpikesMovement2()
    {
        if (timer < waitTime)
        {
            anim.SetBool("Up", false);

        }
        if (timer > waitTime)
        {
            anim.SetBool("Up", true);
            

        }

        if (timer > maxTime)
        {
            timer = 0;

        }

    }

    private void SpikesMovement3()
    {
        if (timer < waitTime)
        {
            anim.SetBool("Up", true);

        }
        if (timer > waitTime)
        {
            anim.SetBool("Up", false);

        }

        if (timer > maxTime)
        {
            timer = 0;

        }


    }

    void Type()
    {
        switch (Change)
        {
            case spikes.Spikes1:
                SpikesMovement1();
                break;
            case spikes.Spikes2:
                SpikesMovement2();
                break;
            case spikes.Spikes3:
                SpikesMovement3();
                break;

            default:
                Debug.Log("No se puso un estilo de Spikes");
                break;

        }
    }
}
