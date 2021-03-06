using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookAt : Enemy
{

    GameObject target;
    [SerializeField] Transform explosion;



    private void Awake()
    {
        target = GameObject.FindWithTag("Player");
    }
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
        //Quaternion newRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        //transform.rotation = newRotation;

        Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        transform.LookAt(targetPosition);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TailHitBox"))
        {
            Destroy(this.gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);

        }
    }

}
