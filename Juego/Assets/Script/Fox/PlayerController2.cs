using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
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

    public Canvas canvas;
    Animator anim;
    Rigidbody rb;

    [SerializeField] private GameObject startPosition;
    private Stack<GameObject> collectables;

    public Light isProtected;

    private void Awake()
    {
        startPosition = GameObject.FindWithTag("StartPosition");
    }
    void Start()
    {
        //StartP();
        collectables = new Stack<GameObject>();

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2f, 0.0f);

    }



    void Update()
    {
        timer += Time.deltaTime;

        Movement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (timer > jumpTime)
            {
                anim.SetBool("isJumping", true);
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                timer = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (collectables.Count > 0)
            {
                switch (collectables.Pop().name)
                {
                    case "Shield":
                        isProtected.gameObject.SetActive(true);
                        break;
                    case "HealthPlusRed":
                        Debug.Log("isHealing");
                        break;
                    default:
                        break;
                }
                canvas.GetComponent<CanvasController>().UpdateItems(collectables);
            }
        }

        if (isProtected.gameObject.activeSelf)
        {
            protectionTimer += Time.deltaTime;
        }
        if(protectionTimer > 5)
        {
            isProtected.gameObject.SetActive(false);
            protectionTimer = 0;
        }
    }



    /// <summary>
    /// Metodo que controla el movimiento del Player
    /// </summary>
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

    /// <summary>
    /// Interacciones con otros elementos, como triggers
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FloorEnd"))
        {
            playerLives -= 1;
            StartP();
            health = 10;
        }

        if (playerLives < 1)
        {
            Destroy(this.gameObject);
        }


        else if (other.gameObject.CompareTag("Diamond"))
        {
            diamonds += 1;

        }

        else if (other.gameObject.CompareTag("Collectable"))
        {
            collectables.Push(other.gameObject);
            canvas.GetComponent<CanvasController>().UpdateItems(collectables);
        }

        else if (other.gameObject.CompareTag("Enemy"))
        {
            if(isProtected.gameObject.activeSelf != true)
            {
                canvas.GetComponent<CanvasController>().Damage();
                health -= 1;

                if (health < 1)
                {
                    playerLives -= 1;
                    transform.position = new Vector3(-42.4f, 4f, -41.6f);
                    health += 10;
                }
            }
        

        }

        if (diamonds > 9)
        {
            if (other.gameObject.CompareTag("Portal"))
            {
                Debug.Log("Terminaste el nivel");
                StartP();
            }
        }

        if (other.gameObject.CompareTag("Portal"))
        {
            if (diamonds < 8)
            {
                Debug.Log("Te faltan diamantes para terminar el nivel");
            }
        }

        if (playerLives < 1)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            anim.SetBool("isJumping", false);
        }
    }

    private void StartP()
    {
        transform.position = startPosition.transform.position;
    }
}
