using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    private void ChangeCamera()
    {
        GameEventsManager.Instance.cameraEvents.CameraChanged();
    }
}
