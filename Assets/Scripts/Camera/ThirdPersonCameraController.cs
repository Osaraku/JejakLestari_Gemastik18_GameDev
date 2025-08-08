using System;
using Unity.Cinemachine;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonCameraController : MonoBehaviour
{
    [SerializeField] private float zoomSpeed = 2f;
    [SerializeField] private float zoomLerpSpeed = 10f;
    [SerializeField] private float minDistance = 6f;
    [SerializeField] private float maxDistance = 12f;

    private InputSystem_Actions inputActions;
    private InputAction mouseZoomAction;

    private CinemachineCamera cam;
    private CinemachineOrbitalFollow orbitalFollow;
    private CinemachineInputAxisController inputAxisController;
    private Vector2 scrollDelta;

    private float targetZoom;
    private float currentZoom;
    private bool isCameraLocked;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Enable();

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mouseZoomAction = InputSystem.actions.FindAction("MouseZoom");
        mouseZoomAction.performed += HandleMouseScroll;

        isCameraLocked = false;
        Cursor.lockState = CursorLockMode.Locked;

        cam = GetComponent<CinemachineCamera>();
        orbitalFollow = cam.GetComponent<CinemachineOrbitalFollow>();
        inputAxisController = cam.GetComponent<CinemachineInputAxisController>();

        targetZoom = currentZoom = orbitalFollow.Radius;
    }

    private void OnEnable()
    {
        GameEventsManager.Instance.cameraEvents.onCameraLock += SetCameraLock;
    }

    private void OnDisable()
    {
        GameEventsManager.Instance.cameraEvents.onCameraLock -= SetCameraLock;
    }

    private void HandleMouseScroll(InputAction.CallbackContext context)
    {
        if (isCameraLocked)
        {
            return;
        }

        scrollDelta = context.ReadValue<Vector2>();
    }

    private void SetCameraLock(bool isLocked)
    {
        isCameraLocked = isLocked;

        inputAxisController.enabled = !isLocked;

        if (isCameraLocked == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (isCameraLocked)
        {
            return;
        }

        if (scrollDelta.y != 0)
        {
            if (orbitalFollow != null)
            {
                targetZoom = Mathf.Clamp(orbitalFollow.Radius - scrollDelta.y * zoomSpeed, minDistance, maxDistance);
                scrollDelta = Vector2.zero;
            }
        }

        currentZoom = Mathf.Lerp(currentZoom, targetZoom, Time.deltaTime * zoomLerpSpeed);
        orbitalFollow.Radius = currentZoom;
    }
}
