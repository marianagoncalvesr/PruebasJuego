using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    int[] keysUsed;
    Queue<Keys> keys;
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
        Keys key = keys.Dequeue();
       

        switch (key.Lvl)
        {
            case 1:
                anim.SetBool("Key1",true);
                break;

            case 2:
                anim.SetBool("Key2", true);
                break;

            case 3:
                anim.SetBool("Key3", true);
                yield return new WaitForSeconds(2);
                anim.SetBool("DoorOpen", true);
                gameObject.GetComponent<BoxCollider>().enabled = false;

               break;
        }

        yield return new WaitForSeconds(2);
        if (keys.Count > 0)
            UseKeyAnimation();
    }

    public void StartKeys(bool used = false)
    {
        keys = GameManager.instance.GetKeysAvailable(used);
        if (keys.Count > 0)
            UseKeyAnimation();
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartKeys();
        }

    }


}
