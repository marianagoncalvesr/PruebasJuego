using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private int bulletSpeed = 5;

    [SerializeField] float spiderDistance = 15f;


    [SerializeField] private float timer = 0.0f;
    [SerializeField] float waitTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerDistance();
        Direction();

        timer += Time.deltaTime;
    }

    /// <summary>
    /// Direccion y velocidad de la bala. Cuando llega a un limite, se elimina
    /// </summary>
    void Direction()
    {

        transform.Translate(bulletSpeed * Time.deltaTime * Vector3.back);

    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }

    void PlayerDistance()
    {

        if (timer > waitTime)
        {
            Destroy(this.gameObject);
        }
    }
}
