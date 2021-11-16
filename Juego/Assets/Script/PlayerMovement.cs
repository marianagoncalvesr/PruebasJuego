using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Velocidades y fuerzas")]
    public Vector3 jump;
    public float jumpForce = 2.0f;
    [SerializeField] int playerSpeed = 5;
    [SerializeField] int rotationSpeed = 450;


    [Header("Salud")]
    [SerializeField] private int health = 10;

    [Header("Cantidad de Diamantes")]
    [SerializeField] int diamonds = 0;

    [Header("Vidas")]
    [SerializeField] private int playerLives = 3;


    /// <summary>
    /// Animaciones y RB
    /// </summary>
    Animator anim;
    private bool isGrounded;
    Rigidbody rb;


    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
            anim.SetBool("isJumping", false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
            anim.SetBool("isJumping", true);
        }
    }

    void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded == true)
            {
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);

            }
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
        if (playerMovement != Vector3.zero)
        {
            anim.SetBool("isRunning", true);

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
            transform.position = new Vector3(-42.4f, 4f, -41.6f);
        }

        if (playerLives < 1)
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("Diamond"))
        {
            diamonds += 1;

        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("enemyco colision");

            health -= 1;

            if (health < 1)
            {
                playerLives -= 1;
                transform.position = new Vector3(-42.4f, 4f, -41.6f);
                health += 10;
            }

        }
        if (diamonds > 7)
        {
            if (other.gameObject.CompareTag("Portal"))
            {
                Debug.Log("Terminaste el nivel");
                transform.position = new Vector3(-42.4f, 4f, -41.6f);
            }
        }

        if (other.gameObject.CompareTag("Portal"))
        {
            if (diamonds < 8)
            {
                Debug.Log("Te faltan diamantes para terminar el nivel");
            }
        }
    }


}
