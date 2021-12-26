using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public static CanvasController instance;

    [SerializeField] TMPro.TextMeshProUGUI contador;
    TMPro.TextMeshPro cantidad;
    //    public Image damage;
    [SerializeField] Image itemToUse;
    [SerializeField] TMPro.TextMeshProUGUI mensaje;
    [SerializeField] TMPro.TextMeshProUGUI infoMessage;
    [SerializeField] TMPro.TextMeshProUGUI playerLives;
    [SerializeField] float timer = 0;
    [SerializeField] Sprite[] sprites;
    private GameObject player;
    [SerializeField] Image lifeBar;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            player = GameObject.FindWithTag("Player");
           // player.GetComponent<PlayerController>().showInfoScreenEvent += ShowMessage;
        }

    }
    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        lifeBar.fillAmount = player.GetComponent<PlayerController>().Health / player.GetComponent<PlayerController>().MaxHealth;
        playerLives.text = player.GetComponent<PlayerController>().PlayerLives.ToString();
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
