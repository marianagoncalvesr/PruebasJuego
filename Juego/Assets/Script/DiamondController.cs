using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondController : MonoBehaviour
{
    [SerializeField] GameObject Sonido;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(Sonido);
            Destroy(this.gameObject);
        }
    }

}
