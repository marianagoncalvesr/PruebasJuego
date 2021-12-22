using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBoss : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] int speed = 10;
    [SerializeField] float distancePlayer = 3f;
    [SerializeField] GameObject player;
    [SerializeField] GameObject wall;



    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        wall = GameObject.FindWithTag("Wall");

    }
    // Start is called before the first frame update
    void Start()
    {
        //Quaternion lookForward = Quaternion.LookRotation(Vector3.back);
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void BossMovement()
    {

        var distance = Vector3.Distance(gameObject.transform.position, player.transform.position);
       

        if (distance > distancePlayer)
        {
            var Step = speed * Time.deltaTime;
            var TargetPos = player.transform.position;
            TargetPos.y = transform.position.y;
            var relativePos = TargetPos - transform.position;
            Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
            transform.LookAt(targetPosition);
            transform.position = Vector3.MoveTowards(transform.position, TargetPos, Step);
        }
        else if (distance < distancePlayer)
        {

        }

    }



    public void Health()
    {
        health -= 1;
    }

    public void Grow()
    {
        transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
        speed -= 1;
    }

}
