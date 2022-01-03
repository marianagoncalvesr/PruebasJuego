using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloorController : MonoBehaviour
{
    [SerializeField] private int buttomPress = 0;
    [SerializeField] Transform particles;
    [SerializeField] Transform particlesPosition;
    bool particlesActivated;
    Animator anim;
    GameObject player;
    [SerializeField] GameObject warning;

    // Start is called before the first frame update
    void Start()
    {
        particlesActivated = false;
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
    }

    public void ActivateParticles()
    {
        Instantiate(particles, particlesPosition);
        particlesActivated = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (buttomPress == 2 && particlesActivated == false)
        {
            ActivateParticles();

        }
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
        if (other.gameObject.CompareTag("Player"))
            if (buttomPress == 2)
            {
                anim.SetBool("Up", true);
                Destroy(warning.gameObject);
            }

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
