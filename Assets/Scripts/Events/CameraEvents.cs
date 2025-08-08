using System;
using UnityEngine;

public class CameraEvents
{
    public event Action onCameraChangeToFirstPerson;
    public void CameraChangedToFirstPerson()
    {
        if (onCameraChangeToFirstPerson != null)
        {
            onCameraChangeToFirstPerson();
        }
    }

    public event Action onCameraTransitionToFirstPerson;
    public void CameraTransitionedToFirstPerson()
    {
        if (onCameraTransitionToFirstPerson != null)
        {
            onCameraTransitionToFirstPerson();
        }
    }

    public event Action onCameraChangeToThirdPerson;
    public void CameraChangedToThirdPerson()
    {
        if (onCameraChangeToThirdPerson != null)
        {
            onCameraChangeToThirdPerson();
        }
    }

    public event Action onCameraTransitionToThirdPerson;
    public void CameraTransitionedToThirdPerson()
    {
        if (onCameraTransitionToThirdPerson != null)
        {
            onCameraTransitionToThirdPerson();
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
}
