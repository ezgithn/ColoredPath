using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    public float speed;
    private Rigidbody _rigidbody;
   
    [SerializeField]
    private bool onGround = true;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float gravity = -20f;

    //Jump
    [SerializeField]
    public float jumpSpeed;
    public float jumpHeight;
    public float jumpTime; 
    public float fallTime; 
    public float smoothTime;
    public int extraJump;
    private int _extraJumpsValue;
    private bool _isJumping = false;

    [SerializeField]
    private Vector3 velocity = Vector3.zero;
    public float groundDistance = 0.1f;

    [SerializeField]
    public float turningSpeed;

    private void Awake()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    void Start()
    {
        _extraJumpsValue = extraJump;
    }

    private void Update()
    {
        if (Input.GetAxis("Vertical") < 0)
        {
            _rigidbody.AddForce(Vector3.right * speed);
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            _rigidbody.AddForce(-Vector3.right * speed);
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            _rigidbody.AddForce(Vector3.forward * speed);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            _rigidbody.AddForce(-Vector3.forward * speed);
        }

        bool isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        if (isGrounded)
        {
            _extraJumpsValue = extraJump;
            velocity.y = 0;
            onGround = true;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y = jumpSpeed * jumpHeight;
                _rigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
                onGround = false;
                _isJumping = true;
            }
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space) && _extraJumpsValue > 0)
            {
                velocity.y = jumpSpeed * jumpHeight;
                _rigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
                _extraJumpsValue--;
                _isJumping = true;
            }
        }

        if (_isJumping)
        {
            float jumpHeightCurrent = velocity.y - transform.position.y;
            float jumpTimeCurrent = Mathf.Sqrt(2 * jumpHeightCurrent / Physics.gravity.magnitude);

            if (jumpTimeCurrent < jumpTime)
            {
                velocity.y = Mathf.SmoothDamp(velocity.y, 0, ref velocity.y, smoothTime);
            }
            else if (jumpTimeCurrent > jumpTime && jumpTimeCurrent < fallTime)
            {
                velocity.y = Mathf.SmoothDamp(velocity.y, -jumpSpeed, ref velocity.y, smoothTime);
            }
            else if (jumpTimeCurrent > fallTime)
            {
                velocity.y = Mathf.SmoothDamp(velocity.y, -jumpSpeed, ref velocity.y, smoothTime);
            }
            if (transform.position.y <= velocity.y && _isJumping)
            {
                _isJumping = false;
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
            _extraJumpsValue = extraJump;
        }

        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.transform.parent.gameObject);
        }
    }
}
