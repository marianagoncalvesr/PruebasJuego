using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{

    [Header("Velocidades y fuerzas")]
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public float jumpTime = 1.0f;
    public float timer = 0;
    private float protectionTimer = 0;


    [Header("Salud")]
    [SerializeField] private float health;
    [SerializeField] private float maxHealth = 10;

    [Header("Cantidad de Diamantes")]
    public int diamonds = 0;

    [Header("Vidas")]
    [SerializeField] private int playerLives = 3;

    [SerializeField] private int playerSpeed = 3;
    [SerializeField] private int rotationSpeed = 250;

    //[SerializeField] private Canvas canvas;
    Animator anim;
    Rigidbody rb;

    [SerializeField] private GameObject startPosition;
    private Stack<GameObject> collectables;

    private bool isProtected;
    [SerializeField] GameObject healing;
    private GameObject tailHitBox;

    [Space]
    [Header("Events")]
    [SerializeField] public UnityEvent onTotalDiamantsCollected;
    [SerializeField] public UnityEvent onLevelNotCompleted;
    [SerializeField] public UnityEvent onGameStarted;

    public float DiamondsQuantity { get => diamonds; }
    public float MaxHealth { get => maxHealth; }
    public float Health { get => health; }
    public int PlayerLives { get => playerLives; }

    public event Action CharacterWithOutLifeEvent;
    public event Action<string> showInfoScreenEvent;
    public event Action healingEvent;

    private bool puedeMoverse = false;


    private void Awake()
    {
        startPosition = GameObject.FindWithTag("StartPosition");
        //CharacterWithOutLifeEvent += canvas.GetComponent<CanvasController>().CharacterDanger;
        healingEvent += HealingPlayer;
        healingEvent += ActivateHealingParticles;

    }

    void Start()
    {
        StartP();
        collectables = new Stack<GameObject>();
        health = 10;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2f, 0.0f);


    }



    void Update()
    {
        timer += Time.deltaTime;
        if (puedeMoverse == false)
        {
            Movement();
            Jump();
            Attack();
        }

        Collectables();
        PlayerDeath();

    }

    public void Stunear()
    {
        StartCoroutine(CambiarEstado());
    }

    public IEnumerator CambiarEstado()
    {
        puedeMoverse = true;
        anim.SetBool("isRunning", false);
        yield return new WaitForSeconds(3f);
        puedeMoverse = false;

    }

    /// Metodo que controla el movimiento del Player
    void Movement()
    {
        float ejeH = Input.GetAxis("Horizontal");
        float ejeV = Input.GetAxis("Vertical");

        Vector3 playerMovement = new Vector3(ejeH, 0, ejeV);
        playerMovement.Normalize();

        if (ejeV != 0 || ejeH != 0)
        {
            anim.SetBool("isRunning", true);
            anim.SetBool("isJumping", false);

        }
        else
        {
            anim.SetBool("isRunning", false);

        }

        transform.Translate(playerSpeed * ejeV * Time.deltaTime * transform.forward, Space.World);
        this.transform.Rotate(Vector3.up * ejeH * rotationSpeed * Time.deltaTime);
    }
    /// Interacciones con otros elementos, como triggers
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FloorEnd"))
        {
            playerLives -= 1;
            StartP();
            health = 10;
        }

        else if (other.gameObject.CompareTag("Diamond"))
        {
            diamonds += 1;
            showInfoScreenEvent("diamante recogido!");

            if (diamonds > 9)
            {
                onTotalDiamantsCollected.Invoke();
            }
        }

        else if (other.gameObject.CompareTag("Collectable"))
        {
            collectables.Push(other.gameObject);
            showInfoScreenEvent.Invoke($"{other.gameObject.name} recogido!");

        }

        else if (other.gameObject.CompareTag("Enemy"))
        {
            if (!isProtected)
            {
                health -= 1;

                if (health < 1)
                {
                    playerLives -= 1;
                    StartP();
                    health += 10;
                }
                // showInfoScreenEvent.Invoke($"Lastimado por {other.gameObject.name}!");

            }

        }

        if (diamonds > 9)
        {
            if (other.gameObject.CompareTag("Portal"))
            {
                showInfoScreenEvent.Invoke($"NIVEL TERMINADO!! ");
                GameManager.instance.PauseUnPauseGame(0);
            }

        }

        if (other.gameObject.CompareTag("Portal"))
        {
            if (diamonds < 8)
            {
                onLevelNotCompleted.Invoke();
            }
        }

        if (other.gameObject.CompareTag("Portal1"))
        {
            SceneManager.LoadScene("Prueba Mariana");
        }
        if (diamonds > 19)
        {
            if (other.gameObject.CompareTag("Portal Final"))
            {
                SceneManager.LoadScene("Null Level");
            }
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            anim.SetBool("isJumping", false);
        }
    }
    /// Posicion inicial del player
    private void StartP()
    {
        if (startPosition != null)
            transform.position = startPosition.transform.position;
        onGameStarted.Invoke();
    }
    ///Salto
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (timer > jumpTime)
            {
                anim.SetBool("isJumping", true);

                anim.SetBool("isRunning", false);
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                timer = 0;
            }
        }
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetBool("isAttacking", true);
            GameObject.FindWithTag("TailHitBox").GetComponent<BoxCollider>().enabled = true;

        }

    }
    ///funciones de los objetos que se van recolectando
    private void Collectables()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (collectables.Count > 0)
            {
                switch (collectables.Pop().name)
                {
                    case "Shield":
                        isProtected = true;
                        showInfoScreenEvent.Invoke("Shield Activado!");
                        break;
                    case "HealthPlusRed":
                        healingEvent.Invoke();
                        break;
                    default:
                        break;
                }
                // canvas.GetComponent<CanvasController>().UpdateItems(collectables);
            }
        }

        if (isProtected)
        {
            protectionTimer += Time.deltaTime;
        }
        if (protectionTimer > 5)
        {
            isProtected = false;
            showInfoScreenEvent.Invoke("Shield Desactivado!");
            protectionTimer = 0;
        }
    }
    /// Accion despues de que se acaban las vidas
    private void PlayerDeath()
    {
        if (playerLives < 1)
        {
            Destroy(this.gameObject);
        }
    }
    ///Eventos

    private void ActivateHealingParticles()
    {
        StartCoroutine(HandleHealingParticles(healing));
    }
    private IEnumerator HandleHealingParticles(GameObject healing)
    {
        healing.SetActive(true);
        showInfoScreenEvent.Invoke("Vida restaurada!");
        yield return new WaitForSeconds(4f);
        healing.SetActive(false);

    }
    private void HealingPlayer()
    {
        health = 10;
    }

    private void Diamonds()
    {
        diamonds = 20;
    }
}
