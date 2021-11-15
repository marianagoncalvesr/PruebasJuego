using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        if (player.transform.position.z < -20)
        {
            InvokeRepeating("Spawner", 1f, 3f);
  
        }


    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawner()
    {
        Instantiate(bullet, transform.position, transform.rotation);

    }

}
