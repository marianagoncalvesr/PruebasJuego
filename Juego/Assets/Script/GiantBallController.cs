using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantBallController : MonoBehaviour
{
    [SerializeField] private int ballSpeed = 10;


    [SerializeField] private float timer = 0.0f;
    [SerializeField] float waitTime = 7.5f;

    [SerializeField] private int speedRotation = 5;

    [SerializeField] private GameObject player;

    enum changes { Movement = 1, Rotate }
    [SerializeField] private changes Change;

    Animator anim;

    [SerializeField] bool activate = true;
    [SerializeField] bool activateRotation = true;

    [SerializeField] GameObject activator;



    // Start is called before the first frame update
    void Start()
    {
        activate = true;
        player = GameObject.FindWithTag("Player");
        activator = GameObject.FindWithTag("Activator");
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if (activate == true && activateRotation == true)
        {
            
            Type();
        }

        
    }
    // Update is called once per frame
    void Update()
    {

    }
    void Rotation()
    {
        if (activateRotation == true)
        {
            this.transform.Rotate(speedRotation, 0f, 0f * Time.deltaTime);
        }
    }
    void Direction()
    {
        if (activate == true)
        {
            anim.SetBool("Grow", true);
            transform.Translate(ballSpeed * Time.deltaTime * Vector3.forward);
        }

    }


    //private void OnTriggerEnter(Collider other)
    //{
    //    if (player)
    //    {
    //        player.GetComponent<PlayerController>().Damage();
    //    }
    //}

    void Type()
    {
        switch (Change)
        {
            case changes.Movement:
                Direction();
                break;
            case changes.Rotate:
                Rotation();
                break;
            default:
                break;
        }
    }

    //public void GiantBallActivate()
    //{
    //    activate = true;
    //    activateRotation = true;
    //}

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Rock"))
        {
            activate = false;
            activateRotation = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player -1 live");
            player.GetComponent<PlayerController>().LostLive();
            Destroy(this.gameObject);
            activator.GetComponent<BallActivatorController>().ThisPosition();
        }
    }




}
