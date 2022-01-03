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
    public event Action healingEvent;

    private bool puedeMoverse = false;


    //camera

    [SerializeField] Transform camPivot;
    [SerializeField] Transform cam;
    float heading;
    Vector3 input;
    Vector3 cameraRotation;


    private CharacterController characterController;

    void Prueba()
    {
        input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input = Vector3.ClampMagnitude(input, 1);

        camPivot.rotation = Quaternion.Euler(0, heading, 0);

        Vector3 camF = cam.forward;

        Vector3 camR = cam.right;

        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;

        transform.position += (camF * input.y + camR * input.x) * playerSpeed * Time.deltaTime;

        //Rotation
        float ejeH = Input.GetAxis("Horizontal");
        float ejeV = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up, ejeH * Time.deltaTime);

        //// mouse rotation
        heading += Input.GetAxis("Mouse X") * Time.deltaTime * 180;


        Quaternion newRotation = Quaternion.Euler(0, heading, 0);
        transform.rotation = newRotation;

        //Animation




        if (ejeV != 0 || ejeH != 0)
        {
            anim.SetBool("isRunning", true);
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isRunning", false);

        }
    }



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
            Prueba();
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

    void Movement()
    {
        float ejeH = Input.GetAxis("Horizontal");
        float ejeV = Input.GetAxis("Vertical");

        Vector3 playerMovement = new Vector3(ejeH, 0, ejeV);
        playerMovement.Normalize();
        transform.Translate(playerSpeed * Time.deltaTime * playerMovement, Space.World);

        if (playerMovement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(playerMovement, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        if (ejeV != 0 || ejeH != 0)
        {
            anim.SetBool("isRunning", true);
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isRunning", false);

        }

    }
    /// Metodo que controla el movimiento del Player
    //void Movement()
    //{
    //    float ejeH = Input.GetAxis("Horizontal");
    //    float ejeV = Input.GetAxis("Vertical");

    //    Vector3 playerMovement = new Vector3(ejeH, 0, ejeV);
    //    playerMovement.Normalize();

    //    if (ejeV != 0 || ejeH != 0)
    //    {
    //        anim.SetBool("isRunning", true);
    //        anim.SetBool("isJumping", false);
    //    }
    //    else
    //    {
    //        anim.SetBool("isRunning", false);

    //    }

    //    transform.Translate(playerSpeed * ejeV * Time.deltaTime * transform.forward, Space.World);
    //    this.transform.Rotate(Vector3.up * ejeH * rotationSpeed * Time.deltaTime);
    //}
    /// Interacciones con otros elementos, como triggers
    private void OnTriggerEnter(Collider other)
    {
        try
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
                GameManager.instance.CurrentStats.Diamants++;

                if (diamonds > 9)
                {
                    onTotalDiamantsCollected.Invoke();
                }
            }

            else if (other.gameObject.CompareTag("Health"))
            {
                health = 10;
            }

            else if (other.gameObject.CompareTag("Enemy"))
            {
                if (!isProtected && !anim.GetBool("isAttacking"))
                {
                    health -= 1;

                    if (health < 1)
                    {
                        playerLives -= 1;
                        StartP();
                        health += 10;
                    }

                }

            }

            if (diamonds > 9)
            {
                if (other.gameObject.CompareTag("Portal"))
                {
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

            if (diamonds > 19)
            {
                if (other.gameObject.CompareTag("Portal Final"))
                {
                    // SceneManager.LoadScene("Null Level");
                }
            }
        }
        catch (Exception)
        {


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
            GameObject.FindWithTag("TailHitBox").GetComponent<SphereCollider>().enabled = true;

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
            //   showInfoScreenEvent.Invoke("Shield Desactivado!");
            protectionTimer = 0;
        }
    }

    public void AttackProtection()
    {
        StartCoroutine(ProtectPlayer());

    }
    private IEnumerator ProtectPlayer()
    {
        Debug.Log("protegido");
        isProtected = true;
        yield return new WaitForSeconds(2);
        isProtected = false;
        Debug.Log("Desprotegido");
    }

    private void PlayerDeath()
    {
        if (playerLives < 1)
        {
            Destroy(this.gameObject);
        }
        if (health == 0)
        {
            playerLives -= 1;
            health = 10;
            StartP();
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

    public void LostLive()
    {
        playerLives -= 1;
        StartP();
    }
    public void Damage()
    {
        health -= 1;
    }
}
