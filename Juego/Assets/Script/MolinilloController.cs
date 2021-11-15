using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolinilloController: MonoBehaviour
{

    [SerializeField] GameObject barra_1;
    [SerializeField] GameObject barra_2;
    Transform b1;
    Transform b2;

    void Start()
    {
        b1 = barra_1.gameObject.GetComponent<Transform>();
        b2 = barra_2.gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        b1.transform.Rotate(new Vector3(0,0 , 100) * Time.deltaTime);
        b2.transform.Rotate(new Vector3(0, 0, -100) * Time.deltaTime);


    }
}
