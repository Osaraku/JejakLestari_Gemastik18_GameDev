using TMPro;
using UnityEngine;

public class InteractUI : MonoBehaviour
{
    [SerializeField] private GameObject container;
    [SerializeField] private TextMeshProUGUI interactText;

    private void Update()
    {
        if (PlayerController.Instance.GetInteractableObject() != null)
        {
            Show(PlayerController.Instance.GetInteractableObject());
        }
        else
        {
            Hide();
        }
    }

    private void Show(IInteractable interactable)
    {
        container.SetActive(true);
        interactText.text = interactable.GetInteractText();
    }

    private void Hide()
    {
        container.SetActive(false);
    }
}
