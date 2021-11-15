using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondController : MonoBehaviour
{
    [SerializeField] GameObject Sonido;

    public static int cantidadDiamantes;

    static DiamondController()
    {
        cantidadDiamantes = 0;
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            cantidadDiamantes++;
            Instantiate(Sonido);
            Destroy(this.gameObject);
        }
    }

}
