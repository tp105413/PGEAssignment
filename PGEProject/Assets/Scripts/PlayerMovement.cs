using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
        //Vector3 move = Vector3.zero;

        //if (Input.GetKey(KeyCode.W))
        //{
        //    move += Vector3.forward;
        //}

        //if (Input.GetKey(KeyCode.S))
        //{
        //    move += Vector3.back;
        //}

        //if (Input.GetKey(KeyCode.A))
        //{
        //    move += Vector3.left;
        //}

        //if (Input.GetKey(KeyCode.D))
        //{
        //    move += Vector3.right;
        //}

        //transform.position += move * moveSpeed * Time.deltaTime;
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void PlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    void MovePlayer()
    {
        // Calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.linearVelocity = new Vector3(moveDirection.x * moveSpeed, moveDirection.y, moveDirection.z * moveSpeed);
    }
}
