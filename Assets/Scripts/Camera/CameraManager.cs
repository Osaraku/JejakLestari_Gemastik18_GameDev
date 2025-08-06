using System;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private GameObject thirdPersonCamera;
    [SerializeField] private GameObject firstPersonCamera;
    [SerializeField] private Animator cameraTransition;

    private bool onFirstPerson;
    private bool cameraLock;

    private void Start()
    {
        ActivateThirdPersonCamera();
        GameEventsManager.Instance.cameraEvents.onCameraChange += ChangeCamera;
        GameEventsManager.Instance.cameraEvents.onCameraTransition += CameraTransition;
    }

    private void CameraTransition()
    {
        cameraTransition.SetTrigger("Change");
    }

    public void ChangeCamera()
    {
        if (onFirstPerson)
        {
            ActivateThirdPersonCamera();
        }
        else
        {
            ActivateFirstPersonCamera();
        }
    }

    private void ActivateThirdPersonCamera()
    {
        thirdPersonCamera.SetActive(true);
        firstPersonCamera.SetActive(false);
        onFirstPerson = false;
    }

    private void ActivateFirstPersonCamera()
    {
        firstPersonCamera.SetActive(true);
        thirdPersonCamera.SetActive(false);
        onFirstPerson = true;
    }
}
