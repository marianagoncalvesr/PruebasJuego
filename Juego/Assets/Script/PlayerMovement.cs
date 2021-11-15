using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 jump;
    public float jumpForce = 2.0f;

    [SerializeField] int diamonds = 0;

    [SerializeField] private int playerLives = 3;

    [SerializeField] int playerSpeed = 5;
    [SerializeField] int rotationSpeed = 450;

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
        if (collision.gameObject.CompareTag("Floor")) { 
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
    void Movement()
    {
        float ejeH = Input.GetAxis("Horizontal");
        float ejeV = Input.GetAxis("Vertical");
        
        Vector3 playerMovement = new Vector3(ejeH, 0, ejeV);
        playerMovement.Normalize();
        if(playerMovement != Vector3.zero)
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            playerLives -= 1;
            transform.position = new Vector3(-42.4f, 4f, -41.6f);

            if (playerLives < 1)
            {
                Destroy(this.gameObject);
            }
        }

        if (other.gameObject.CompareTag("Diamond"))
        {
            diamonds += 1;

        }
    }

}
