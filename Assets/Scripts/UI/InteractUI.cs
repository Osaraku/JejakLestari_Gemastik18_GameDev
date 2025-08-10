using System;
using TMPro;
using UnityEngine;

public class InteractUI : MonoBehaviour
{
    [SerializeField] private GameObject container;
    [SerializeField] private TextMeshProUGUI interactText;
    private bool onBoat = false;

    private void OnEnable()
    {
        GameEventsManager.Instance.playerEvents.onPlayerModeChangeToBoat += HideBoat;
        GameEventsManager.Instance.playerEvents.onPlayerModeChangeToHuman += ShowBoat;
    }

    private void OnDisable()
    {
        GameEventsManager.Instance.playerEvents.onPlayerModeChangeToBoat -= HideBoat;
        GameEventsManager.Instance.playerEvents.onPlayerModeChangeToHuman -= ShowBoat;
    }

    private void HideBoat()
    {
        onBoat = true;
    }

    private void ShowBoat()
    {
        onBoat = false;
    }

    private void Update()
    {
        if (PlayerController.Instance.GetInteractableObject() != null)
        {
            if (onBoat)
            {
                Hide();
            }
            else
            {
                Show(PlayerController.Instance.GetInteractableObject());
            }
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
