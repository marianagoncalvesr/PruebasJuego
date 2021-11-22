using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerShooter : MonoBehaviour
{
    [Header("GameObjects Asociados")]
    [SerializeField] GameObject bullet;

    [Header("Velocidades y variables")]
    [SerializeField] float waitTime = 2.0f;
    [SerializeField] float timer = 0.0f;
    [SerializeField] float playerDistance = 15f;
    private float repeatRate = 3.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > repeatRate)
        {
            if (Input.GetKeyDown(KeyCode.E))
                Spawner();
        }
    }

    /// <summary>
    /// Instancia el prefab de la bala
    /// </summary>
    void Spawner()
    {
        Instantiate(bullet, transform.forward, transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");
    }
}