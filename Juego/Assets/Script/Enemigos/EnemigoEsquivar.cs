using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoEsquivar : MonoBehaviour
{

    [SerializeField] Transform[] waypoints;
    Vector3 siguientePosicion;
    [SerializeField] float velocidad = 5.0f;
    [SerializeField] float distanciaCambio = 0.5f;
    [SerializeField] int numeroSiguientePosicion = 0;

    // Start is called before the first frame update
    void Start()
    {
        siguientePosicion = waypoints[0].position;
    }

    // Update is called once per frame
    void Update()
    {
         transform.position = Vector3.MoveTowards(
            transform.position,
            siguientePosicion,
            velocidad * Time.deltaTime);

        if (Vector3.Distance(transform.position,
            siguientePosicion) < distanciaCambio)
        {
            numeroSiguientePosicion++;
            if (numeroSiguientePosicion >= waypoints.Length)
                numeroSiguientePosicion = 0;
            siguientePosicion =
                waypoints[numeroSiguientePosicion].position;

        }
    }
}
