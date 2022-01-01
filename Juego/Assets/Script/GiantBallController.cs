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

    [SerializeField] bool activate = false;
    [SerializeField] bool activateRotation = false;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        anim = GetComponent<Animator>();


    }
    private void FixedUpdate()
    {
        if (activate == true)
        {
            Type();
        }
        else
        {

        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    void Rotation()
    {
            this.transform.Rotate(speedRotation, 0f, 0f * Time.deltaTime);
    }
    void Direction()
    {
        anim.SetBool("Grow", true);
        transform.Translate(ballSpeed * Time.deltaTime * Vector3.forward);

    }


    private void OnTriggerEnter(Collider other)
    {
        if (player)
        {
            player.GetComponent<PlayerController>().Damage();
        }
    }

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

    public void GiantBallActivate()
    {
        //activateRotation = true;
        activate = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Rock"))
        {
            Debug.Log("colision con piedra");
            activate = false;
            //activateRotation = false;
        }
    }


}
