using UnityEngine;

public class CameraTransitionThird : MonoBehaviour
{
    private Animator animator;

    private void ChangeCameraFirst()
    {
        GameEventsManager.Instance.cameraEvents.CameraChangedToFirstPersonCamera();
    }

    private void ChangeCameraThird()
    {
        GameEventsManager.Instance.cameraEvents.CameraChangedToThirdPersonCamera();
    }
}
