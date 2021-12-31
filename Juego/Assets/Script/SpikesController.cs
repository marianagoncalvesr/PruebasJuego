using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesController : MonoBehaviour
{
    Animator anim;
    [SerializeField] private float timer = 0.0f;
    GameObject player;

    [SerializeField] private float tap = 0f;
    enum spikes { Spikes1 = 1, Spikes2 }
    [SerializeField] private spikes Change;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
       
    }

    // Update is called once per frame
    void Update()
    {
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            tap += 1;

        }
        if (tap == 1)
        {
            anim.SetBool("Up", false);
        }
        if (tap == 2)
        {
            
            anim.SetBool("Up", true);
            tap = 0;
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

            default:
                Debug.Log("No se puso un estilo de Spikes");
                break;

        }
    }
}
