using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private InputAction submitAction;
    private InputAction clickAction;

    private void Start()
    {
        submitAction = InputSystem.actions.FindAction("Submit");
        clickAction = InputSystem.actions.FindAction("Click");
    }

    private void Update()
    {
        if (submitAction.WasPressedThisFrame())
        {
            GameEventsManager.Instance.inputEvents.SubmitPressed();
        }
        if (clickAction.WasPressedThisFrame())
        {
            GameEventsManager.Instance.inputEvents.ClickPressed();
        }
    }
}
