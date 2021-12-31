using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float speed = 5.0f;
    [SerializeField] protected float changeDistance = 0.5f;
    Vector3 temp;


    private void Awake()
    {
    }
    public void DestroySpider()
    {
        temp = transform.localScale;
        temp.y -= 0.25f;
        transform.localScale = temp;

        if (temp.y == 0)
        {

            Destroy(this.gameObject);
            GameManager.instance.CurrentStats.Enemies++;

        }
    }
  

}

