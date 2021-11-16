using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [Header("GameObjects Asociados")]
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject player;

    [Header("Velocidades y variables")]
    [SerializeField] float waitTime = 2.0f;
    [SerializeField] float timer = 0.0f;
    [SerializeField] float playerDistance = 15f;
    private float repeatRate = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Fox");

        InvokeRepeating("Spawner", 0.3f, 0.3f);

    }

    // Update is called once per frame
    void Update()
    {
        //timer += Time.deltaTime;
        //if (player != null)
        //{
        //    Vector3 distancia = (player.transform.position - transform.position);

        //    if (distancia.magnitude < playerDistance && timer > waitTime)
        //    {
        //        Instantiate(bullet, transform.position, transform.rotation);
        //        timer = 0;
        //    }
        //}
    }

    /// <summary>
    /// Instancia el prefab de la bala
    /// </summary>
    void Spawner()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");  
    }
}
