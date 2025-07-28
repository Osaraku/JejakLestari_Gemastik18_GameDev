using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }
    public Vector2 movementInput { get; private set; }

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float sprintSpeedIncrease = 2f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private Transform cameraOrientation;
    [SerializeField] private bool shouldFaceMoveDirection = true;

    private CharacterController controller;
    private PlayerState playerState;
    private InputAction moveAction;
    private InputAction sprintAction;
    private InputAction jumpAction;
    private InputAction interactAction;
    private Vector3 velocity;

    private bool isMoving;
    private bool isSprinting;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerState = GetComponent<PlayerState>();
    }

    private void Start()
    {

        moveAction = InputSystem.actions.FindAction("Move");
        sprintAction = InputSystem.actions.FindAction("Sprint");
        jumpAction = InputSystem.actions.FindAction("Jump");
        interactAction = InputSystem.actions.FindAction("Interact");
    }

    private void Update()
    {
        UpdateMovementState();
        Move();
        Sprint();
        Jump();
        Interact();
    }

    private void UpdateMovementState()
    {
        if (isMoving && isSprinting)
        {
            playerState.SetPlayerMovementState(PlayerMovementState.Sprinting);
        }

        else if (isMoving)
        {
            playerState.SetPlayerMovementState(PlayerMovementState.Running);
        }
        else
        {
            playerState.SetPlayerMovementState(PlayerMovementState.Idling);
        }

        if (!GetIsGrounded() && velocity.y >= 0f)
        {
            playerState.SetPlayerMovementState(PlayerMovementState.Jumping);
        }
        else if (!GetIsGrounded() && velocity.y < 0f)
        {
            playerState.SetPlayerMovementState(PlayerMovementState.Falling);
        }
    }

    private void Move()
    {
        Vector3 forward = cameraOrientation.forward;
        Vector3 right = cameraOrientation.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        movementInput = moveAction.ReadValue<Vector2>();
        movementInput = movementInput.normalized;

        Vector3 moveDirection = forward * movementInput.y + right * movementInput.x;
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);

        if (shouldFaceMoveDirection && moveDirection.sqrMagnitude > 0.001f)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            float rotateSpeed = 10f;
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotateSpeed * Time.deltaTime);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        isMoving = moveDirection != Vector3.zero;
    }

    private void Sprint()
    {
        if (sprintAction.WasPressedThisFrame())
        {
            moveSpeed += sprintSpeedIncrease;
            isSprinting = true;
        }
        else if (sprintAction.WasReleasedThisFrame())
        {
            moveSpeed -= sprintSpeedIncrease;
            isSprinting = false;
        }
    }

    private void Jump()
    {
        if (jumpAction.WasPressedThisFrame() && GetIsGrounded())
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void Interact()
    {
        if (interactAction.WasPressedThisFrame() && GetIsGrounded())
        {
            playerState.SetPlayerMovementState(PlayerMovementState.Gathering);
        }
    }

    public bool GetIsGrounded()
    {
        return controller.isGrounded;
    }
}
