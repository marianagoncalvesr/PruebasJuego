using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject portal;

    private void Update()
    {
        if (DiamondController.cantidadDiamantes > 14 && !portal.activeInHierarchy)
        {
            portal.SetActive(true);
        }
    }

}
