using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    Vector3 nextPosition;
    [SerializeField] int numberNextPosition = 0;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float changeDistance = 0.5f;
   


    // Start is called before the first frame update
    void Start()
    {
        nextPosition = waypoints[0].position;
        
    }

    // Update is called once per frame
    void Update()
    {
        WayPoints();
    }

    private void WayPoints()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, nextPosition) < changeDistance)
        {
            numberNextPosition++;

            if (numberNextPosition >= waypoints.Length)

                numberNextPosition = 0;
            nextPosition = waypoints[numberNextPosition].position;

        }
    }
}
