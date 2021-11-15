using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject player;

    private float waitTime = 2.0f;
    private float timer = 0.0f;
    private float playerDistance = 15f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        //   InvokeRepeating("Spawner", 1f, 3f);
        timer = 2;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Vector3 distancia = (player.transform.position - transform.position);

        if (distancia.magnitude < playerDistance && timer > waitTime) 
        {
            Instantiate(bullet, transform.position, transform.rotation);
            timer = 0;
        }
    }

    void Spawner()
    {
        Instantiate(bullet, transform.position, transform.rotation);

    }

}
