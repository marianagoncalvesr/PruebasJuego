using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnerController : MonoBehaviour
{
    [Header("GameObjects Asociados")]
    [SerializeField] GameObject ball;
    [SerializeField] GameObject player;

    [Header("Velocidades y variables")]
    [SerializeField] float waitTime = 2.0f;
    [SerializeField] float timer = 0.0f;
    [SerializeField] float playerDistance = 15f;
    private float repeatRate = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        PlayerDistance();
    }

    /// <summary>
    /// Instancia el prefab de la bala
    /// </summary>
    void Spawner()
    {
        Instantiate(ball, transform.position, transform.rotation);
    }

    void PlayerDistance()
    {
        if (player != null)
        {
            Vector3 distance = (player.transform.position - transform.position);

            if (distance.magnitude < playerDistance && timer > waitTime)
            {
                Instantiate(ball, transform.position, transform.rotation);
                timer = 0;
            }
        }
    }
}
