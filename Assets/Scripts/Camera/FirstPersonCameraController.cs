using UnityEngine;

public class FirstPersonCameraController : MonoBehaviour
{
    [SerializeField] private Vector2 turn;
    [SerializeField] Transform thirdPersonCamera;

    private bool canRotate = true;

    private void Start()
    {

    }

    private void Update()
    {
        if (canRotate)
        {
            turn.x += Input.GetAxis("Mouse X");
            turn.y += Input.GetAxis("Mouse Y");
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        }
    }

    public void SetInitialRotation(float x, float y)
    {
        turn.x = x;
        turn.y = y;
    }

    public void SetCanRotate(bool rotation)
    {
        canRotate = rotation;

        if (!canRotate)
        {
            Cursor.lockState = CursorLockMode.None;
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        }
    }
}
