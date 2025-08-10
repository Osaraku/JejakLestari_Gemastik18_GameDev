using System;
using TMPro;
using UnityEngine;

public class HudUI : MonoBehaviour
{
    [SerializeField] private GameObject visual;
    [SerializeField] private GameObject boatVisual;
    [SerializeField] private GameObject moneyUI;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI poinText;
    [SerializeField] private PlayerLevel playerLevel;
    [SerializeField] private TextMeshProUGUI riverCleanText;

    private int trashCollected = 0;


    private void Start()
    {
        moneyText.text = playerLevel.currentMoney.ToString();
        levelText.text = playerLevel.currentLevel.ToString();
        poinText.text = playerLevel.currentExperience.ToString();

        BoatHide();
    }

    void OnEnable()
    {
        GameEventsManager.Instance.playerEvents.onMoneyChange += MoneyChange;
        GameEventsManager.Instance.playerEvents.onPlayerLevelChange += LevelChange;
        GameEventsManager.Instance.playerEvents.onPlayerExperienceChange += ExperienceChange;

        GameEventsManager.Instance.cameraEvents.onCameraChangeToFirstPersonJournal += Hide;
        GameEventsManager.Instance.cameraEvents.onCameraChangeToThirdPersonJournal += Show;
        GameEventsManager.Instance.cameraEvents.onCameraChangeToFirstPersonCamera += Hide;
        GameEventsManager.Instance.cameraEvents.onCameraChangeToThirdPersonCamera += Show;

        GameEventsManager.Instance.playerEvents.onPlayerModeChangeToHuman += Show;
        GameEventsManager.Instance.playerEvents.onPlayerModeChangeToBoat += Hide;
        GameEventsManager.Instance.playerEvents.onPlayerModeChangeToHuman += BoatHide;
        GameEventsManager.Instance.playerEvents.onPlayerModeChangeToBoat += BoatShow;

        GameEventsManager.Instance.trashEvents.onRiverTrashCollected += RiverTrashCollected;
    }

    void OnDisable()
    {
        GameEventsManager.Instance.playerEvents.onMoneyChange -= MoneyChange;
        GameEventsManager.Instance.playerEvents.onPlayerLevelChange -= LevelChange;
        GameEventsManager.Instance.playerEvents.onPlayerExperienceChange -= ExperienceChange;

        GameEventsManager.Instance.cameraEvents.onCameraChangeToFirstPersonJournal -= Hide;
        GameEventsManager.Instance.cameraEvents.onCameraChangeToThirdPersonJournal -= Show;
        GameEventsManager.Instance.cameraEvents.onCameraChangeToFirstPersonCamera -= Hide;
        GameEventsManager.Instance.cameraEvents.onCameraChangeToThirdPersonCamera -= Show;

        GameEventsManager.Instance.playerEvents.onPlayerModeChangeToHuman -= Show;
        GameEventsManager.Instance.playerEvents.onPlayerModeChangeToBoat -= Hide;
        GameEventsManager.Instance.playerEvents.onPlayerModeChangeToHuman -= BoatHide;
        GameEventsManager.Instance.playerEvents.onPlayerModeChangeToBoat -= BoatShow;

        GameEventsManager.Instance.trashEvents.onRiverTrashCollected -= RiverTrashCollected;
    }

    private void RiverTrashCollected()
    {
        trashCollected++;
        riverCleanText.text = "Terambil " + trashCollected + "/" + "20 \nSampah";
    }

    private void Hide()
    {
        visual.SetActive(false);
    }

    private void Show()
    {
        visual.SetActive(true);
    }

    private void BoatHide()
    {
        boatVisual.SetActive(false);
    }

    private void BoatShow()
    {
        boatVisual.SetActive(true);
    }

    private void ExperienceChange(int exp)
    {
        poinText.text = exp.ToString();
    }

    private void LevelChange(int lvl)
    {
        levelText.text = lvl.ToString();
    }

    private void MoneyChange(int money)
    {
        moneyText.text = money.ToString();
    }
}
