using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeakPoint : MonoBehaviour
{
    private GameObject player;
    public Enemy spider;
    public int liv = 1;
   

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(liv == 0)
        {
            DestroySpider();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (player)
        {
            liv = 0; 
        }
    }

    private void DestroySpider()
    {
        spider.DestroySpider();
    }



    
}
