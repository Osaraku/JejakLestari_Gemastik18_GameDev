using System;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private GameObject thirdPersonCamera;
    [SerializeField] private GameObject firstPersonCamera;
    [SerializeField] private Animator cameraTransition;
    [SerializeField] private Animator cameraTransitionThird;

    private void Start()
    {
        ActivateThirdPersonCamera();
    }

    private void OnEnable()
    {
        GameEventsManager.Instance.cameraEvents.onCameraChangeToFirstPersonJournal += ActivateFirstPersonCamera;
        GameEventsManager.Instance.cameraEvents.onCameraChangeToThirdPersonJournal += ActivateThirdPersonCamera;
        GameEventsManager.Instance.cameraEvents.onCameraTransitionToFirstPersonJournal += CameraTransitionToFirstPerson;
        GameEventsManager.Instance.cameraEvents.onCameraTransitionToThirdPersonJournal += CameraTransitionToThirdPerson;
        GameEventsManager.Instance.cameraEvents.onCameraChangeToFirstPersonCamera += ActivateFirstPersonCamera;
        GameEventsManager.Instance.cameraEvents.onCameraChangeToThirdPersonCamera += ActivateThirdPersonCamera;
        GameEventsManager.Instance.cameraEvents.onCameraTransitionToFirstPersonCamera += CameraTransitionToFirstPersonCamera;
        GameEventsManager.Instance.cameraEvents.onCameraTransitionToThirdPersonCamera += CameraTransitionToThirdPersonCamera;
    }

    private void OnDisable()
    {
        GameEventsManager.Instance.cameraEvents.onCameraChangeToFirstPersonJournal -= ActivateFirstPersonCamera;
        GameEventsManager.Instance.cameraEvents.onCameraChangeToThirdPersonJournal -= ActivateThirdPersonCamera; ;
        GameEventsManager.Instance.cameraEvents.onCameraTransitionToFirstPersonJournal -= CameraTransitionToFirstPerson;
        GameEventsManager.Instance.cameraEvents.onCameraTransitionToThirdPersonJournal -= CameraTransitionToThirdPerson;
        GameEventsManager.Instance.cameraEvents.onCameraChangeToFirstPersonCamera -= ActivateFirstPersonCamera;
        GameEventsManager.Instance.cameraEvents.onCameraChangeToThirdPersonCamera -= ActivateThirdPersonCamera;
        GameEventsManager.Instance.cameraEvents.onCameraTransitionToFirstPersonCamera -= CameraTransitionToFirstPersonCamera;
        GameEventsManager.Instance.cameraEvents.onCameraTransitionToThirdPersonCamera -= CameraTransitionToThirdPersonCamera;
    }

    private void CameraTransitionToFirstPerson()
    {
        cameraTransition.SetTrigger("Change");
    }

    private void CameraTransitionToThirdPerson()
    {
        cameraTransition.SetTrigger("ChangeThird");
    }
    private void CameraTransitionToFirstPersonCamera()
    {
        cameraTransitionThird.SetTrigger("Change");
    }

    private void CameraTransitionToThirdPersonCamera()
    {
        cameraTransitionThird.SetTrigger("ChangeThird");
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
