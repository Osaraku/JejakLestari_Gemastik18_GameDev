using System;
using System.Collections.Generic;
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
    [SerializeField] private Transform thirdPersonCamera;
    [SerializeField] private Transform firstPersonCamera;
    [SerializeField] private bool shouldFaceMoveDirection = true;
    [SerializeField] private InventoryUI inventoryUI;

    private CharacterController controller;
    private PlayerState playerState;
    private InputAction moveAction;
    private InputAction sprintAction;
    private InputAction jumpAction;
    private InputAction interactAction;
    private InputAction photoCameraAction;
    private InputAction journalCameraAction;
    private Vector3 velocity;
    private PlayerInventory playerInventory;
    private Transform cameraOrientation;

    private bool canMove = true;
    private bool isMoving;
    private bool isSprinting;

    private void Awake()
    {
        Instance = this;
        controller = GetComponent<CharacterController>();
        playerState = GetComponent<PlayerState>();
        playerInventory = new PlayerInventory(UseItem);
    }

    private void Start()
    {

        moveAction = InputSystem.actions.FindAction("Move");
        sprintAction = InputSystem.actions.FindAction("Sprint");
        jumpAction = InputSystem.actions.FindAction("Jump");
        interactAction = InputSystem.actions.FindAction("Interact");
        photoCameraAction = InputSystem.actions.FindAction("PhotoCamera");
        journalCameraAction = InputSystem.actions.FindAction("JournalCamera");

        cameraOrientation = thirdPersonCamera;
        inventoryUI.SetInventory(playerInventory);
    }

    private void OnEnable()
    {
        GameEventsManager.Instance.playerEvents.onPlayerMovementLock += SetMovementLock;
    }
    private void OnDisable()
    {
        GameEventsManager.Instance.playerEvents.onPlayerMovementLock -= SetMovementLock;
    }

    private void Update()
    {
        if (canMove)
        {
            UpdateMovementState();
            Move();
            Sprint();
            Jump();
            Interact();
        }
        ChangeCamera();
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

    private void SetMovementLock(bool isLocked)
    {
        canMove = !isLocked;
    }

    private void ChangeCamera()
    {
        FirstPersonCameraController fpController = firstPersonCamera.GetComponent<FirstPersonCameraController>();

        if (photoCameraAction.WasPressedThisFrame() && GetIsGrounded())
        {
            if (cameraOrientation == thirdPersonCamera)
            {
                cameraOrientation = firstPersonCamera;
                fpController.SetInitialRotation(transform.eulerAngles.y, transform.eulerAngles.x);
                fpController.SetCanRotate(true);

                GameEventsManager.Instance.cameraEvents.CameraTransitionedToFirstPersonCamera();
                GameEventsManager.Instance.inputEvents.ChangeInputEventContext(InputEventContext.CAMERA);
                Debug.Log("pressed");
            }
            else
            {
                cameraOrientation = thirdPersonCamera;
                GameEventsManager.Instance.cameraEvents.CameraTransitionedToThirdPersonCamera();
                GameEventsManager.Instance.inputEvents.ChangeInputEventContext(InputEventContext.DEFAULT);
            }
        }

        if (journalCameraAction.WasPressedThisFrame() && GetIsGrounded())
        {
            if (cameraOrientation == thirdPersonCamera)
            {
                cameraOrientation = firstPersonCamera;
                fpController.SetInitialRotation(transform.eulerAngles.y, transform.eulerAngles.x);

                fpController.SetCanRotate(false);
                canMove = false;
                GameEventsManager.Instance.cameraEvents.CameraTransitionedToFirstPersonJournal();

            }
            else
            {
                cameraOrientation = thirdPersonCamera;
                Cursor.lockState = CursorLockMode.Locked;
                canMove = true;
                GameEventsManager.Instance.cameraEvents.CameraTransitionedToThirdPersonJournal();
            }
        }
    }

    private void Interact()
    {
        if (interactAction.WasPressedThisFrame() && GetIsGrounded())
        {
            IInteractable interactable = GetInteractableObject();
            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }

    public IInteractable GetInteractableObject()
    {
        List<IInteractable> interactableList = new List<IInteractable>();
        float interactRange = 1f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out IInteractable interactable))
            {
                interactableList.Add(interactable);
            }
        }

        IInteractable closestInteractable = null;
        foreach (IInteractable interactable in interactableList)
        {
            if (closestInteractable == null)
            {
                closestInteractable = interactable;
            }
            else
            {
                if (Vector3.Distance(transform.position, interactable.GetTransform().position) < Vector3.Distance(transform.position, closestInteractable.GetTransform().position))
                {
                    closestInteractable = interactable;
                }
            }
        }
        return closestInteractable;
    }

    public PlayerInventory GetPlayerInventory()
    {
        return playerInventory;
    }

    private void UseItem(Item item)
    {
        switch (item.itemType)
        {
            case Item.ItemType.BottleTrash:
                playerInventory.RemoveItem(new Item { itemType = Item.ItemType.BottleTrash, amount = 1 });
                break;
        }
    }

    public bool GetIsGrounded()
    {
        return controller.isGrounded;
    }
}
