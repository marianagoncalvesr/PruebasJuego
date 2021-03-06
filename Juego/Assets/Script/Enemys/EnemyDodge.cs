using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDodge : Enemy
{

    [SerializeField] Transform[] waypoints;
    Vector3 nextPosition;
    [SerializeField] int numeroSiguientePosicion = 0;

    [SerializeField] public Transform particle;


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
    private void OnTriggerEnter(Collider other)
    {

        if ( other.CompareTag("TailHitBox"))
        {

            Instantiate(particle, transform.position,Quaternion.identity);
            Destroy(this.gameObject);
        }

    }

}
