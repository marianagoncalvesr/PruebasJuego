using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBossWeakPoint : MonoBehaviour
{
    private GameObject player;
    public SpiderBoss bossScript;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (player.gameObject)
        {
            bossScript.Health();
            bossScript.Grow();

        }
    }


}
