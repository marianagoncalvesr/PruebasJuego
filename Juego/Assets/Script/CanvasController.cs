using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public static CanvasController instance;

    [SerializeField] TMPro.TextMeshProUGUI contador;
    TMPro.TextMeshPro cantidad;
    public Image damage;
    public Image itemToUse;
    public TMPro.TextMeshProUGUI mensaje;
    public TMPro.TextMeshProUGUI infoMessage;
    public float timer = 0;
    public Sprite[] sprites;
    [SerializeField] private Image paws;
    private GameObject player;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            player = GameObject.FindWithTag("Player");
            player.GetComponent<PlayerController>().showInfoScreenEvent += ShowMessage;
        }

    }
    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        DamageController();
        contador.text = DiamondController.cantidadDiamantes.ToString();
    }
    public void CharacterDanger()
    {
        StartCoroutine(ActivateMessage("Personaje con poca vida!"));
    }
    public void ShowMessage(string message)
    {
        StartCoroutine(ActivateMessage(message));

    }
    public IEnumerator ActivateMessage(string text)
    {
        infoMessage.text = text;
        infoMessage.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        infoMessage.gameObject.SetActive(false);
    }

    public void PawsHealth()
    {
        paws?.gameObject.SetActive(false);
    }
    public void Damage()
    {
        damage?.gameObject.SetActive(true);
    }
    private void DamageController()
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
