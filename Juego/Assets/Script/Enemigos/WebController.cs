using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebController : MonoBehaviour
{
    [SerializeField] private int bulletSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Direction();
    }

    /// <summary>
    /// Direccion y velocidad de la bala. Cuando llega a un limite, se elimina
    /// </summary>
    void Direction()
    {

        transform.Translate(bulletSpeed * Time.deltaTime * Vector3.forward);
        if (this.transform.position.z < -100 || this.transform.position.z > 100 ||
            this.transform.position.x < -100 || this.transform.position.x > 100)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
