using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected GameObject player;
    [SerializeField] protected GameObject tail;
    [SerializeField] protected float speed = 5.0f;
    [SerializeField] protected float changeDistance = 0.5f;

    Vector3 temp;
    private int liv = 1;



    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        player = GameObject.FindWithTag("TailHitBox");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (liv == 0)
            DestroySpider();
    }

    public void DestroySpider()
    {
        temp = transform.localScale;
        temp.y -= 0.25f;
        transform.localScale = temp;

        if(temp.y == 0)
        {
            Destroy(this.gameObject);
            GameManager.instance.CurrentStats.Enemies++;

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (tail)
        {
            liv = 0;
        }
    }

}
