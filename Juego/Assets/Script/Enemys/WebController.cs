using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebController : MonoBehaviour
{
    [SerializeField] private int bulletSpeed = 5;

    [SerializeField] float spiderDistance = 15f;
    private GameObject spider;
    [SerializeField] private int timer = 2;

    // Start is called before the first frame update
    void Start()
    {
        spider = GameObject.FindWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDistance();
        Direction();
    }

    /// <summary>
    /// Direccion y velocidad de la bala. Cuando llega a un limite, se elimina
    /// </summary>
    void Direction()
    {

        transform.Translate(bulletSpeed * Time.deltaTime * Vector3.forward);

        //if (this.transform.position.z < -100 || this.transform.position.z > 100 ||
        //    this.transform.position.x < -100 || this.transform.position.x > 100)
        //{
        //    Destroy(this.gameObject);
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }

    void PlayerDistance()
    {
        //if (spider == null)
        //{
        //    Vector3 distance = transform.position + transform.position;

        //    if (distance.magnitude < spiderDistance)
        //    {
        //        Destroy(this.gameObject);
        //    }
        //}

        if (Vector3.Distance(spider.transform.position, transform.position) > spiderDistance)
        {
            Destroy(this.gameObject);
        }
    }
}
