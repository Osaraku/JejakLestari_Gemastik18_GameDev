using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
    [SerializeField] Transform mainCamera;

    // Update is called once per frame
    void LateUpdate()
    {
        float mainCameraYaw = mainCamera.eulerAngles.y;
        transform.rotation = Quaternion.Euler(90f, mainCameraYaw, 0f);
    }
}
