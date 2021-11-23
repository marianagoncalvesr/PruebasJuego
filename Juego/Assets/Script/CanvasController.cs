using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI contador;
    TMPro.TextMeshPro cantidad;
    public Image damage;
    public Image itemToUse;
    public TMPro.TextMeshProUGUI mensaje;
    public float timer = 0;
    public Sprite[] sprites;


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

    public void UpdateItems(Stack<GameObject> items)
    {
        if (items.Count == 0)
        {
            itemToUse.gameObject.SetActive(false); 
            mensaje.gameObject.SetActive(false);
        }
        else
        {
            foreach (Sprite sprite in sprites)
            {
                if (items.Peek().name.Contains(sprite.name))
                {
                    itemToUse.gameObject.SetActive(true);
                    mensaje.gameObject.SetActive(true);
                    itemToUse.sprite = null;
                    itemToUse.sprite = sprite;
                }
            }
        }


    }

}
