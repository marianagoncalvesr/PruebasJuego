using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindeJuego : MonoBehaviour
{
    // Start is called before the first frame update

    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("gameManager.CompleteLevel()");
    }

}
