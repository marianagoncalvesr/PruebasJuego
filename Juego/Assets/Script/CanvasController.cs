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
    [SerializeField] Image lifeBar;
    private GameObject player;
    [SerializeField] GameObject[] itemStat;
    [SerializeField] GameObject templateItemStat;
    [SerializeField] GameObject panelStat;
    [SerializeField] GameObject ListContainer;

    public void ActivateEndLevelStats(bool enable = true)
    {
        if (enable)
            ShowStats();
        panelStat.SetActive(enable);

    }

    private void ShowStats()
    {
        try
        {
            Stats stats = GameManager.instance.CurrentStats;

            itemStat[0].GetComponent<ItemManager>().points.text = stats.PointsDiamants.ToString();
            itemStat[0].GetComponent<ItemManager>().quantity.text = stats.Diamants.ToString();

            itemStat[1].GetComponent<ItemManager>().points.text = stats.PointsEnemies.ToString();
            itemStat[1].GetComponent<ItemManager>().quantity.text = stats.Enemies.ToString();

            itemStat[2].GetComponent<ItemManager>().points.text = stats.PointsLivesRemain.ToString();
            itemStat[2].GetComponent<ItemManager>().quantity.text = stats.LivesRemain.ToString();

            foreach (PowerUpItem item in GameManager.instance.CurrentStats.ListPowerUps)
            {
                if (!item.Used)
                {
                    var listItem = GameObject.Instantiate(templateItemStat, ListContainer.transform);
                    var listItemScript = listItem.GetComponent<ItemManager>();
                    listItemScript.text.text = item.Name.ToString();
                    listItemScript.points.text = item.Points.ToString();
                }

            }
        }
        catch (System.Exception ex)
        {

        }


    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            player = GameObject.FindWithTag("Player");
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
