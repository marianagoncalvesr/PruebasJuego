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

    public bool isGrounded;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    void Movement()
    {
        float ejeH = Input.GetAxis("Horizontal");
        float ejeV = Input.GetAxis("Vertical");

        Vector3 playerMovement = new Vector3(ejeH, 0, ejeV);
        playerMovement.Normalize();

        if (ejeV != 0)
            Debug.Log("V:" + ejeV);
        transform.Translate(playerSpeed * ejeV * Time.deltaTime * transform.forward, Space.World);
        Debug.Log("H:" + ejeH);
        this.transform.Rotate(Vector3.up * ejeH * rotationSpeed * Time.deltaTime);

        //if (ejeH == 1 || ejeH == -1)
        //{
        //    if (ejeH != 0)
        //       
        //    Quaternion toRotation = Quaternion.LookRotation(playerMovement, Vector3.up);

        //    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        //}

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("touch");
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
