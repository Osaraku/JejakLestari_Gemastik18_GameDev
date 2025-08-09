using UnityEngine;

public class CameraUI : MonoBehaviour
{
    [SerializeField] private GameObject Visual;

    private void Start()
    {
        Hide();
    }

    private void OnEnable()
    {
        GameEventsManager.Instance.cameraEvents.onCameraChangeToFirstPersonCamera += Show;
        GameEventsManager.Instance.cameraEvents.onCameraChangeToThirdPersonCamera += Hide;
    }

    private void OnDisable()
    {
        GameEventsManager.Instance.cameraEvents.onCameraChangeToFirstPersonCamera -= Show;
        GameEventsManager.Instance.cameraEvents.onCameraChangeToThirdPersonCamera -= Hide;
    }

    private void Show()
    {
        Visual.SetActive(true);
    }

    private void Hide()
    {
        Visual.SetActive(false);
    }

}
