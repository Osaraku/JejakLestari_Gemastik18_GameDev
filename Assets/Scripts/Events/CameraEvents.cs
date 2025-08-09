using System;
using UnityEngine;

public class CameraEvents
{
    public event Action onCameraChangeToFirstPersonJournal;
    public void CameraChangedToFirstPersonJournal()
    {
        if (onCameraChangeToFirstPersonJournal != null)
        {
            onCameraChangeToFirstPersonJournal();
        }
    }

    public event Action onCameraTransitionToFirstPersonJournal;
    public void CameraTransitionedToFirstPersonJournal()
    {
        if (onCameraTransitionToFirstPersonJournal != null)
        {
            onCameraTransitionToFirstPersonJournal();
        }
    }

    public event Action onCameraChangeToThirdPersonJournal;
    public void CameraChangedToThirdPersonJournal()
    {
        if (onCameraChangeToThirdPersonJournal != null)
        {
            onCameraChangeToThirdPersonJournal();
        }
    }

    public event Action onCameraTransitionToThirdPersonJournal;
    public void CameraTransitionedToThirdPersonJournal()
    {
        if (onCameraTransitionToThirdPersonJournal != null)
        {
            onCameraTransitionToThirdPersonJournal();
        }
    }

    public event Action<bool> onCameraLock;
    public void CameraLock(bool isLocked)
    {
        if (onCameraLock != null)
        {
            onCameraLock(isLocked);
        }
    }

    public event Action onCameraChangeToFirstPersonCamera;
    public void CameraChangedToFirstPersonCamera()
    {
        if (onCameraChangeToFirstPersonCamera != null)
        {
            onCameraChangeToFirstPersonCamera();
        }
    }

    public event Action onCameraTransitionToFirstPersonCamera;
    public void CameraTransitionedToFirstPersonCamera()
    {
        if (onCameraTransitionToFirstPersonCamera != null)
        {
            onCameraTransitionToFirstPersonCamera();
        }
    }

    public event Action onCameraChangeToThirdPersonCamera;
    public void CameraChangedToThirdPersonCamera()
    {
        if (onCameraChangeToThirdPersonCamera != null)
        {
            onCameraChangeToThirdPersonCamera();
        }
    }

    public event Action onCameraTransitionToThirdPersonCamera;
    public void CameraTransitionedToThirdPersonCamera()
    {
        if (onCameraTransitionToThirdPersonCamera != null)
        {
            onCameraTransitionToThirdPersonCamera();
        }
    }
}
