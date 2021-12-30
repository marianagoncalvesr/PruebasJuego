using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private int ballSpeed = 10;


    [SerializeField] private float timer = 0.0f;
    [SerializeField] float waitTime = 7.5f;

    [SerializeField] private int speedRotation = 5;

    enum changes { Movement = 1, Rotate}

    [SerializeField] private changes Change;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        timer += Time.deltaTime;
        
    }

    private void FixedUpdate()
    {
        Type();
    }
    void Direction()
    {
        transform.Translate(ballSpeed * Time.deltaTime * Vector3.forward);
    }
    void Rotation()
    {
        this.transform.Rotate(speedRotation, 0f, 0f * Time.deltaTime);
    }

    void Timer()
    {
        if (timer > waitTime)
        {
            Destroy(this.gameObject);
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
}
