using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float runSpeed = 9f;

    public float jumpForce = 8f;
    public float gravity = 20f;

    public float lookSensitivity = 0.2f;
    public float lookAngleLimit = 90f;

    Camera mainCamera;
    CharacterController characterController;
    InputAction moveInput;
    InputAction runInput;
    InputAction jumpInput;
    bool jumped = false;

    float currentMoveSpeed = 0f;
    Vector3 moveDirection = Vector3.zero;
    float lookAngle = 0f;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = GetComponentInChildren<Camera>();
        characterController = GetComponent<CharacterController>();

        moveInput = InputSystem.actions.FindAction("Move");
        runInput = InputSystem.actions.FindAction("Sprint");
        jumpInput = InputSystem.actions.FindAction("Jump");
        jumpInput.started += Jumped;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        currentMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveVector = moveInput.ReadValue<Vector2>();
        Vector2 mouseDelta = new Vector2(Mouse.current.delta.x.ReadValue(), Mouse.current.delta.y.ReadValue());

        if (!characterController.isGrounded) jumped = false;

        HandleMovement(moveVector);
        HandleLooking(mouseDelta);
    }

    void HandleMovement(Vector2 moveVector)
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float oldY = moveDirection.y;

        Vector2 newSpeed = new Vector2(moveVector.y * currentMoveSpeed, moveVector.x * currentMoveSpeed);

        moveDirection = (forward * newSpeed.x) + (right * newSpeed.y);

        moveDirection.y = (jumped && characterController.isGrounded) ? jumpForce : oldY;

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        currentMoveSpeed = runInput.IsPressed() ? runSpeed : moveSpeed;

        characterController.Move(moveDirection * Time.deltaTime);
    }

    void Jumped(InputAction.CallbackContext _)
    {
        jumped = true;
    }

    void HandleLooking(Vector2 mouseDelta)
    {
        lookAngle += -mouseDelta.y * lookSensitivity;
        lookAngle = Mathf.Clamp(lookAngle, -lookAngleLimit, lookAngleLimit);

        mainCamera.transform.localRotation = Quaternion.Euler(lookAngle, 0, 0);
        transform.rotation *= Quaternion.Euler(0, mouseDelta.x * lookSensitivity, 0);
    }
}
