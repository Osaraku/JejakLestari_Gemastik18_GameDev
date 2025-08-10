using System;
using Unity.Cinemachine;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject humanPlayer;
    [SerializeField] private GameObject boatPlayer;
    [SerializeField] private CinemachineCamera ThirdPersonCamera;

    private void OnEnable()
    {
        GameEventsManager.Instance.playerEvents.onPlayerModeChangeToBoat += ChangePlayerToBoat;
        GameEventsManager.Instance.playerEvents.onPlayerModeChangeToHuman += ChangePlayerToHuman;
    }

    private void OnDisable()
    {
        GameEventsManager.Instance.playerEvents.onPlayerModeChangeToBoat -= ChangePlayerToBoat;
        GameEventsManager.Instance.playerEvents.onPlayerModeChangeToHuman -= ChangePlayerToHuman;
    }

    private void ChangePlayerToBoat()
    {
        boatPlayer.SetActive(true);
        humanPlayer.SetActive(false);
        ThirdPersonCamera.Follow = boatPlayer.transform;
    }

    private void ChangePlayerToHuman()
    {
        humanPlayer.SetActive(true);
        boatPlayer.SetActive(false);
        ThirdPersonCamera.Follow = humanPlayer.transform;
    }
}
