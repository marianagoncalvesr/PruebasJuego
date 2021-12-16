using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour
{
    enum speed { Rotation1 = 1, Rotation2, Rotation3 }

    [SerializeField] private speed Rotation;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Rotate();
    }

    void Rotate()
    {
        

        switch (Rotation)
        {
            case speed.Rotation1:
                transform.Rotate(0f, 1f, 0f * Time.deltaTime);
                break;
            case speed.Rotation2:
                transform.Rotate(0f, 3f, 0f * Time.deltaTime);
                break;
            case speed.Rotation3:
                transform.Rotate(0f, 5f, 0f * Time.deltaTime);
                break;

        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = null;
        }

    }


}
