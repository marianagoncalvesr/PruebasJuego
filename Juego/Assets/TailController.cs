using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailController : MonoBehaviour
{
    // Start is called before the first frame update



    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Enemy"))
        {
      
            Destroy(other.gameObject);
        }


    }


}
