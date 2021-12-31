using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformController : MonoBehaviour
{
    GameObject player;
    Animator anim;
    [SerializeField] float timer = 0f;
    bool start = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (start == true)
            timer += Time.deltaTime;

        Fall();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetBool("Shake", true);
            start = true;

        }
        if (other.gameObject == player)
        {
            player.transform.parent = transform;
        }

    }

    void Fall()
    {
        if (timer > 2)
        {
            anim.SetBool("Fall", true);

        }

        if (timer > 7)
        {
            anim.SetBool("Fall", false);
            anim.SetBool("Shake", false);
            start = false;

        }
        if (start == false)
        {
            timer = 0;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
    
            player.transform.parent = null;
            timer = 0;
        }

    }

}
