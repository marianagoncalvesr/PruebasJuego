using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMaxDistance : MonoBehaviour
{
    private int distance = 40;
    [SerializeField] GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MaxDistance();
        ball = GameObject.FindWithTag("Ball");
    }

    private void FixedUpdate()
    {
        
    }

    private void MaxDistance()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, distance))
        {
            if (hit.collider.CompareTag("Ball"))
            {
                Debug.Log("colision de raycast");
                Destroy(ball.gameObject);
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.forward * distance);
    }
}
