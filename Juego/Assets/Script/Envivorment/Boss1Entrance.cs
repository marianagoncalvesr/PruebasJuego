using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Entrance : MonoBehaviour
{
    [SerializeField] GameObject player;

    [SerializeField] SpiderBoss bossScript;

    bool playerEntering;

    [SerializeField] private float timer = 0.0f;
    [SerializeField] private float waitTime = 3f;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        if (timer > waitTime)
        {
            if (playerEntering == true)
            {
                bossScript.BossMovement();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            playerEntering = true;
            timer = 0;
        }
    }


}
