using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPoint : MonoBehaviour
{

    private GameObject player;
    public Bosses bossOne;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
      //  bossOne = Bosses.FindWithTag("Boss");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (player)
        {
            bossOne.Health();
        }
    }

}
