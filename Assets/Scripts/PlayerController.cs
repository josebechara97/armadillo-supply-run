using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb; //reference to the GameObject Rigidbody Component
    public float speed = 10f;
    public float jumpForce = 7f;
    public bool grounded;


    // Start is called before the first frame update
    void Start()
    {
        //use GetComponent to create a reference
        this.rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!LevelTimer.isGameOver)
        {

            if (Input.GetKeyDown(KeyCode.Space) && grounded)
            {
                rb.AddForce(Vector3.up * jumpForce * 100);
            }

            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            var motionVector = new Vector3(moveHorizontal, 0.0f, moveVertical);

            if (grounded)
            {
                rb.AddForce(motionVector * speed);
            }  
        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}
