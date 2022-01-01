using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallActivatorController : MonoBehaviour
{
    [SerializeField] GameObject giantBall;
    [SerializeField] GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        giantBall = GameObject.FindWithTag("GiantBall");
        ball = GameObject.FindWithTag("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player colisionando");
            giantBall.GetComponent<GiantBallController>().GiantBallActivate();
            ball.GetComponent<GiantBallController>().GiantBallActivate();
        }
    }



}
