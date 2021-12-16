using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    Vector3 nextPosition;
    [SerializeField] int numberNextPosition = 0;
    [SerializeField] protected float speed = 5.0f;
    [SerializeField] protected float changeDistance = 0.5f;
    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        nextPosition = waypoints[0].position;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(
           transform.position,
           nextPosition,
           speed * Time.deltaTime);

        if (Vector3.Distance(transform.position,
            nextPosition) < changeDistance)
        {
            //transform.Rotate(new Vector3(0, 180, 0));
            numberNextPosition++;

            if (numberNextPosition >= waypoints.Length)
            
                numberNextPosition = 0;
                nextPosition =
                    waypoints[numberNextPosition].position;

        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = null;
        }

    }
}
