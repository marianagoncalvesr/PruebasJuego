using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.SceneManagement;

public class LandingController : MonoBehaviour
{
    //[SerializeField] private InputField


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickPlay()
    {
        SceneManager.LoadScene("Prueba Mariana");
    }
}
