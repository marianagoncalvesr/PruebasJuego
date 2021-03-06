using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosses : MonoBehaviour
{
    [SerializeField] protected EnemyData myData;
    [SerializeField] protected GameObject player;
    [SerializeField] protected GameObject centerPosition;
    //[SerializeField] private GameObject weakPoint;
    [SerializeField] private int health = 10;

    


    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        transform.position = centerPosition.transform.position;
     
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        DestroyBoss();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            myData.lives -= 1;
            transform.position = centerPosition.transform.position;
        }
    }

    protected void FollowPlayer()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Vector3 direction2 = (player.transform.position - transform.position);
        Vector3 centerDirecion = (centerPosition.transform.position - transform.position);
        //Debug.Log(direction2.magnitude);

        if (direction2.magnitude < myData.playerDistance)
        {
            transform.position += myData.speed * direction * Time.deltaTime;
        }
        else
        {
            transform.position += myData.speed * centerDirecion * Time.deltaTime;
        }

    }

    //private void OnCollisionEnter(Collision player)
    //{
    //    if (weakPoint)
    //    {
    //        health -= 1;
    //    }
    //}

    public void Health()
    {
        health -= 1;
    }

    private void DestroyBoss()
    {
        if(health == 0)
        {
            Destroy(this.gameObject);
        }
    }

}
