using System;
using TMPro;
using UnityEngine;

public class HudUI : MonoBehaviour
{
    [SerializeField] private GameObject moneyUI;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI poinText;
    [SerializeField] private PlayerLevel playerLevel;


    private void Start()
    {
        moneyText.text = playerLevel.currentMoney.ToString();
        levelText.text = playerLevel.currentLevel.ToString();
        poinText.text = playerLevel.currentExperience.ToString();
    }

    void OnEnable()
    {
        GameEventsManager.Instance.playerEvents.onMoneyChange += MoneyChange;
        GameEventsManager.Instance.playerEvents.onPlayerLevelChange += LevelChange;
        GameEventsManager.Instance.playerEvents.onPlayerExperienceChange += ExperienceChange;
    }

    void OnDisable()
    {
        GameEventsManager.Instance.playerEvents.onMoneyChange -= MoneyChange;
        GameEventsManager.Instance.playerEvents.onPlayerLevelChange -= LevelChange;
        GameEventsManager.Instance.playerEvents.onPlayerExperienceChange -= ExperienceChange;
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
