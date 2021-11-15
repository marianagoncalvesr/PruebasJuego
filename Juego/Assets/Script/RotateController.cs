using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour
{
    enum speed { Rotation1 =1, Rotation2, Rotation3}

    [SerializeField] private speed Rotation;

    // Start is called before the first frame update
    void Start()
    {
        
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
                transform.Rotate(1f, 0, 0f * Time.deltaTime);
                break;
            case speed.Rotation2:
                transform.Rotate(3f, 0, 0f * Time.deltaTime);
                break;
            case speed.Rotation3:
                transform.Rotate(5f, 0, 0f * Time.deltaTime);
                break;

        }
    }
    

   
}
