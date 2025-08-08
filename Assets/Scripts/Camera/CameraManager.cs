using System;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private GameObject thirdPersonCamera;
    [SerializeField] private GameObject firstPersonCamera;
    [SerializeField] private Animator cameraTransition;

    private void Start()
    {
        ActivateThirdPersonCamera();
    }

    private void OnEnable()
    {
        GameEventsManager.Instance.cameraEvents.onCameraChangeToFirstPerson += ActivateFirstPersonCamera;
        GameEventsManager.Instance.cameraEvents.onCameraChangeToThirdPerson += ActivateThirdPersonCamera;
        GameEventsManager.Instance.cameraEvents.onCameraTransitionToFirstPerson += CameraTransitionToFirstPerson;
        GameEventsManager.Instance.cameraEvents.onCameraTransitionToThirdPerson += CameraTransitionToThirdPerson;
    }

    private void OnDisable()
    {
        GameEventsManager.Instance.cameraEvents.onCameraChangeToFirstPerson -= ActivateFirstPersonCamera;
        GameEventsManager.Instance.cameraEvents.onCameraChangeToThirdPerson -= ActivateThirdPersonCamera; ;
        GameEventsManager.Instance.cameraEvents.onCameraTransitionToFirstPerson -= CameraTransitionToFirstPerson;
        GameEventsManager.Instance.cameraEvents.onCameraTransitionToThirdPerson -= CameraTransitionToThirdPerson;
    }

    private void CameraTransitionToFirstPerson()
    {
        cameraTransition.SetTrigger("Change");
    }

    private void CameraTransitionToThirdPerson()
    {
        cameraTransition.SetTrigger("ChangeThird");
    }

    private void ActivateThirdPersonCamera()
    {
        thirdPersonCamera.SetActive(true);
        firstPersonCamera.SetActive(false);
    }

    private void ActivateFirstPersonCamera()
    {
        firstPersonCamera.SetActive(true);
        thirdPersonCamera.SetActive(false);
    }
}
