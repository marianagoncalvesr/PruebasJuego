using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookAt : Enemy
{
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();
    }

    /// <summary>
    /// Hace que mi enemigo vea a mi Player, sin moverse
    /// </summary>
    void LookAtPlayer()
    {
        Quaternion newRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = newRotation;
    }

}
