using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoEsquivar : MonoBehaviour
{

    [SerializeField] Transform[] waypoints;
    Vector3 nextPosition;
    [SerializeField] float speed = 5.0f;
    [SerializeField] float changeDistance = 0.5f;
    [SerializeField] int numeroSiguientePosicion = 0;
    [SerializeField] int rotationSpeed = 15;

    // Start is called before the first frame update
    void Start()
    {
        nextPosition = waypoints[0].position;
    }

    // Update is called once per frame
    void Update()
    {
         transform.position = Vector3.MoveTowards(
            transform.position,
            nextPosition,
            speed * Time.deltaTime);
        //transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime * rotationSpeed, Space.World);

        if (Vector3.Distance(transform.position,
            nextPosition) < changeDistance)
        {
            transform.Rotate(new Vector3(0, 180, 0));
            numeroSiguientePosicion++;
            if (numeroSiguientePosicion >= waypoints.Length)
                numeroSiguientePosicion = 0;
            nextPosition =
                waypoints[numeroSiguientePosicion].position;

        }
    }
}
