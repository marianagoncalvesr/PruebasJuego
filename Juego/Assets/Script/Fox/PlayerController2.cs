using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PlayerController2 : MonoBehaviour
{

    [Header("Velocidades y fuerzas")]
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public float jumpTime = 1.0f;
    public float timer = 0;
    private float protectionTimer = 0;


    [Header("Salud")]
    [SerializeField] private int health = 10;

    [Header("Cantidad de Diamantes")]
    [SerializeField] int diamonds = 0;

    [Header("Vidas")]
    [SerializeField] private int playerLives = 3;

    [SerializeField] private int playerSpeed = 3;
    [SerializeField] private int rotationSpeed = 3;

    [SerializeField] private Canvas canvas;
    Animator anim;
    Rigidbody rb;

    [SerializeField] private GameObject startPosition;
    private Stack<GameObject> collectables;

    private bool isProtected;
    [SerializeField] GameObject healing;



    [Space]
    [Header("Events")]
    [SerializeField] public UnityEvent onTotalDiamantsCollected;
    [SerializeField] public UnityEvent onLevelNotCompleted;
    [SerializeField] public UnityEvent onGameStarted;

    public event Action CharacterWithOutLifeEvent;
    public event Action<string> showInfoScreenEvent;
    public event Action healingEvent;

    private void Awake()
    {
        startPosition = GameObject.FindWithTag("StartPosition");
       

        CharacterWithOutLifeEvent += canvas.GetComponent<CanvasController>().CharacterDanger;
        showInfoScreenEvent += canvas.GetComponent<CanvasController>().ShowMessage;

        healingEvent += HealingPlayer;
        healingEvent += ActivateHealingParticles;
    }



    void Start()
    {
        StartP();
        collectables = new Stack<GameObject>();

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2f, 0.0f);

        
    }



    void Update()
    {
        timer += Time.deltaTime;

        Movement();
        Jump();
        Collectables();
        PlayerDeath();

        if (health < 2 || playerLives < 2)
        {
            CharacterWithOutLifeEvent.Invoke();
            Debug.Log("Te queda poca vida");
        }

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
            Debug.Log("Diamante recogido");
            if (diamonds > 9)
            {
                onTotalDiamantsCollected.Invoke();
                Debug.Log("El portal esta activado");
            }
        }

        else if (other.gameObject.CompareTag("Collectable"))
        {
            collectables.Push(other.gameObject);
            canvas.GetComponent<CanvasController>().UpdateItems(collectables);
            showInfoScreenEvent.Invoke($"{other.gameObject.name} recogido!");
            Debug.Log("Item recogido");

        }

        else if (other.gameObject.CompareTag("Enemy"))
        {
            if (!isProtected)
            {
                canvas.GetComponent<CanvasController>().Damage();
                canvas.GetComponent<CanvasController>().PawsHealth();
                health -= 1;

                if (health < 1)
                {
                    playerLives -= 1;
                    transform.position = new Vector3(-42.4f, 4f, -41.6f);
                    health += 10;
                }
                showInfoScreenEvent.Invoke($"Lastimado por {other.gameObject.name}!");
                Debug.Log($"Lastimado por {other.gameObject.name}!");

            }


        }

        if (diamonds > 9)
        {
            if (other.gameObject.CompareTag("Portal"))
            {
                showInfoScreenEvent.Invoke("Pasaste de nivel!");
                Debug.Log("Pasaste de nivel");
                SceneManager.LoadScene("Level 2");
            }

        }

        if (other.gameObject.CompareTag("Portal"))
        {
            if (diamonds < 8)
            {
                onLevelNotCompleted.Invoke();
                Debug.Log("te faltan diamantes");
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
        transform.position = startPosition.transform.position;
        onGameStarted.Invoke();
        Debug.Log("Juego comenzado");
    }
    ///Salto
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (timer > jumpTime)
            {
                anim.SetBool("isJumping", true);
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                timer = 0;
            }
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
                        Debug.Log("Escudo activado");
                        break;
                    case "HealthPlusRed":
                        healingEvent.Invoke();
                        Debug.Log("Curado");
                        break;
                    default:
                        break;
                }
                canvas.GetComponent<CanvasController>().UpdateItems(collectables);
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
            Debug.Log("Escudo desactivado");

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
        Debug.Log("Vida restaurada");
        yield return new WaitForSeconds(4f);
        healing.SetActive(false);

    }
    private void HealingPlayer()
    {
        health = 10;
    }
}
