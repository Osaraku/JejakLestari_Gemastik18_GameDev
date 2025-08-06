using System;
using UnityEngine;

public class CameraEvents
{
    public event Action onCameraChange;
    public void CameraChanged()
    {
        if (onCameraChange != null)
        {
            onCameraChange();
        }
    }

    public event Action onCameraTransition;
    public void CameraTransitioned()
    {
        if (onCameraTransition != null)
        {
            onCameraTransition();
        }
    }
}
