using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected GameObject player;
    [SerializeField] protected float speed = 5.0f;
    [SerializeField] protected float changeDistance = 0.5f;

    Vector3 temp;
    


    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroySpider()
    {
        temp = transform.localScale;
        temp.y -= 0.5f;
        transform.localScale = temp;

        if(temp.y == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
