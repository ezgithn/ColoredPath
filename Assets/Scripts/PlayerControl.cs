using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    
    private bool onGround = true;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float gravity = -20f;

    //Jump
    public float jumpSpeed;
    public float jumpHeight;
    public float jumpTime; 
    public float fallTime; 
    public float smoothTime;
    public int extraJump;
    private int extraJumpsValue;
    private bool isJumping = false;

    private Vector3 velocity = Vector3.zero;
    public float groundDistance = 0.1f;




    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        extraJumpsValue = extraJump;
    }

    private void Update()
    {

        if (Input.GetAxis("Vertical") < 0)
        {
            rb.AddForce(Vector3.right * speed);
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            rb.AddForce(-Vector3.right * speed);
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            rb.AddForce(Vector3.forward * speed);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rb.AddForce(-Vector3.forward * speed);
        }

        bool isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        if (isGrounded)
        {
            extraJumpsValue = extraJump;
            velocity.y = 0;
            onGround = true;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y = jumpSpeed;
                rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
                onGround = false;
                isJumping = true;
            }
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space) && extraJumpsValue > 0)
            {
                velocity.y = jumpSpeed;
                rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
                extraJumpsValue--;
                isJumping = true;
            }
        }

        if (isJumping)
        {
            float jumpHeightCurrent = velocity.y - transform.position.y;
            float jumpTimeCurrent = Mathf.Sqrt(2 * jumpHeightCurrent / Physics.gravity.magnitude);

            float timeToTarget = Mathf.Lerp(jumpTime, fallTime, jumpTimeCurrent / jumpTime);
            velocity = transform.position + Vector3.up * jumpHeightCurrent + Vector3.up * Physics.gravity.magnitude * timeToTarget * timeToTarget / 2f;

            transform.position = Vector3.SmoothDamp(transform.position, velocity, ref velocity, smoothTime);

            if (transform.position.y <= velocity.y && isJumping)
            {
                isJumping = false;
            }
        }

    }

    private void FixedUpdate()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
            extraJumpsValue = extraJump;
        }

        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.transform.parent.gameObject);
        }
    }



}
