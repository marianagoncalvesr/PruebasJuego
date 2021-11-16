using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI contadorDiamantes;
    [SerializeField] TMPro.TextMeshProUGUI vidas;
    TMPro.TextMeshPro cantidad;
    public GameObject playerInfo;
    private PlayerMovement pc;
    public Image salud;
    public  GameObject posInicial;

    private void Start()
    {
        pc = playerInfo.GetComponent<PlayerMovement>(); 
        DibujarVida();
    }
    // Update is called once per frame
    void Update()
    {
        try
        {
          
            vidas.text = pc.playerLives.ToString();
            contadorDiamantes.text = DiamondController.cantidadDiamantes.ToString();
        }
        catch (System.Exception)
        {

        }

    }

    public void DibujarVida()
    {
        Transform posImagen = posInicial.transform;
        for (int i = 0; i < pc.health; i++)
        {
            Image health = Instantiate(salud, posImagen.position, Quaternion.identity);
            health.transform.parent = transform;
            posImagen.position = new Vector3(posImagen.position.x + 30, posImagen.position.y, posImagen.position.z);
        }
    }
}
