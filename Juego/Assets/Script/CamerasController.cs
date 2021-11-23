using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasController : MonoBehaviour
{
    public GameObject[] cameras;
    bool camaraAutomatica;
    int camaraActiva;
    int ultimaCamaraUsada;

    [SerializeField] GameObject player;
    //Vector3 personajeLimite = new Vector3(-0f, 1.8f - 12f);


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        camaraActiva = 0;
        ultimaCamaraUsada = 0;
        camaraAutomatica = true;
    }

    // Update is called once per frame
    void Update()
    {
        AutoCamera();
       //CamerawithBottons();
    }

    private void AutoCamera()
    {
        //camaraAutomatica = !camaraAutomatica;

        if (camaraAutomatica == true)
        {
            if (player.transform.position.x > 0)
            {
                camaraActiva = 0;

            }
            if (player.transform.position.z < 28 && player.transform.position.x < 21 && player.transform.position.x > -15)
            {
                camaraActiva = 1;
              
            }


            if (ultimaCamaraUsada != camaraActiva)
            {

                for (int i = 0; i < cameras.Length; i++)
                {
                    if (i != camaraActiva)
                    {
                        Debug.Log("Apgando camara numero: {i}");
                        cameras[i].SetActive(false);
                    }
                }

                Debug.Log("Activando camara numero: {camaraActiva}");
                cameras[camaraActiva].SetActive(true);
                ultimaCamaraUsada = camaraActiva;
            }

        }

       
    }

    private void CamerawithBottons()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            camaraAutomatica = !camaraAutomatica;
        }
        if (camaraAutomatica == false)
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                camaraActiva = 0;
               
            }
            if (Input.GetKeyDown(KeyCode.F2))
            {
                camaraActiva = 1;
              
            }
            if (Input.GetKeyDown(KeyCode.F3))
            {
                camaraActiva = 2;
               
            }
            if (Input.GetKeyDown(KeyCode.F4))
            {
                camaraActiva = 3;
               
            }

            if (ultimaCamaraUsada != camaraActiva)
            {
                for (int i = 0; i < cameras.Length; i++)
                {
                    if (i != camaraActiva)
                    {
                        Debug.Log($"Apgando camara numero: {i}");
                        cameras[i].SetActive(false);
                    }
                }

                Debug.Log("Activando camara numero: {camaraActiva}");
                cameras[camaraActiva].SetActive(true);
            }
        }
    }

}