using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    int[] keysUsed;

    private void Awake()
    {
        keysUsed = new int[3];
           anim = GetComponent<Animator>();
    }


    public void UseKeyAnimation()
    {
        StartCoroutine(StartKeyAnimation());
    }

    private IEnumerator StartKeyAnimation()
    {
        List<Keys> keys = GameManager.instance.GetKeysAvailable();
        if (keys.Count>0)
        {
          
        }
        yield return null;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UseKeyAnimation();
           


        }

    }


}
