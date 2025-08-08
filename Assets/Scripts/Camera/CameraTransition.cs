using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    private Animator animator;

    private void ChangeCameraFirst()
    {
        GameEventsManager.Instance.cameraEvents.CameraChangedToFirstPerson();
    }

    private void ChangeCameraThird()
    {
        GameEventsManager.Instance.cameraEvents.CameraChangedToThirdPerson();
    }
}
