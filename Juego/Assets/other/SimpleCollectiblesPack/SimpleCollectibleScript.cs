using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SimpleCollectibleScript : MonoBehaviour
{

    [SerializeField] int lvl;

    public bool rotate; // do you want it to rotate?

    public float rotationSpeed;


    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < GameManager.instance.DoorKeysTotal.Length; i++)
        {
            if(GameManager.instance.DoorKeysTotal[i].Lvl==lvl &&
                GameManager.instance.DoorKeysTotal[i].Picked == true)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (rotate)
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Collect();
        }
    }

    public void Collect()
    {
        this.gameObject.SetActive(false);
        GameManager.instance.KeyPicked(lvl);

    }
}
