using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITransitionCameraScript : MonoBehaviour
{

    public CinemachineVirtualCamera currentCamera;
    // Start is called before the first frame update
    void Start()
    {
        currentCamera.Priority++;
    }

    public void UpdateCamera(CinemachineVirtualCamera target)
    {
        Debug.Log("---");
        Debug.Log("current: "+ currentCamera.name + " - priority " + currentCamera.Priority);
        Debug.Log("current: " + target.name + " - priority " + target.Priority);

        currentCamera.Priority--;
        currentCamera = target;
        currentCamera.Priority++;

        Debug.Log("current: " + currentCamera.name + " - priority " + currentCamera.Priority);
        Debug.Log("---");

    }


}
