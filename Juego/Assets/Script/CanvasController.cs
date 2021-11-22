using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI contador;
    TMPro.TextMeshPro cantidad;
    public Image damage;
    public float timer = 0;
    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (damage.gameObject.activeInHierarchy)
        {
            timer += Time.deltaTime;
            if (timer > 1f)
            {
                damage?.gameObject.SetActive(false);
                timer = 0;
            }
        }
        contador.text = DiamondController.cantidadDiamantes.ToString();
    }

    public void Damage()
    {
        damage?.gameObject.SetActive(true);
        

    }

}
