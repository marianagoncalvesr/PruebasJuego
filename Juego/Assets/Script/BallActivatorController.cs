using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallActivatorController : MonoBehaviour
{
    [SerializeField] GameObject giantBall;
    [SerializeField] GameObject ball;
    [SerializeField] GameObject bigBall;

    [SerializeField] GameObject nextPosition;

    [SerializeField] GameObject cam;
    [SerializeField] GameObject camNewPosition;



    bool ballActivate = false;
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
            
            ballActivate = true;
            SpawnGiantBall();
            transform.position = nextPosition.transform.position;
            cam.transform.position = camNewPosition.transform.position;
        }

    }

    void SpawnGiantBall()
    {

        Instantiate(bigBall);  
    }

    public void ThisPosition()
    {
        transform.position = new Vector3 (-32.8f, 11.4f, 108.3f);
        
    }


}
