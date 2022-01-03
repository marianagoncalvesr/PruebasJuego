using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdviceController : MonoBehaviour
{
    private int distance = 40;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Warning();
    }

    private void Warning()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, distance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("Necesitas 3 llaves para abrir la puerta");
                
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.forward * distance);
    }
}
