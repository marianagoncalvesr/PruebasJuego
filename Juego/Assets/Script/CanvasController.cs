using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI contador;
     TMPro.TextMeshPro cantidad;

    private void Start()
    {
    
    }
    // Update is called once per frame
    void Update()
    {
        try
        {
            contador.text = DiamondController.cantidadDiamantes.ToString();
        }
        catch (System.Exception)
        {
        }

    }
}
