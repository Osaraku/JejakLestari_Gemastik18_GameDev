using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private int startingLevel = 1;
    [SerializeField] private int startingExperience = 0;
    [SerializeField] private int startingMoney = 50000;
    public int currentLevel;
    public int currentExperience;
    public int currentMoney;

    private void Awake()
    {
        currentLevel = startingLevel;
        currentExperience = startingExperience;
        currentMoney = startingMoney;
    }

    private void OnEnable()
    {
        GameEventsManager.Instance.playerEvents.onExperienceGained += ExperienceGained;
        GameEventsManager.Instance.playerEvents.onMoneyGained += MoneyGained;
    }

    private void OnDisable()
    {
        GameEventsManager.Instance.playerEvents.onExperienceGained -= ExperienceGained;
        GameEventsManager.Instance.playerEvents.onMoneyGained -= MoneyGained;
    }

    private void Start()
    {
        GameEventsManager.Instance.playerEvents.PlayerLevelChange(currentLevel);
        GameEventsManager.Instance.playerEvents.PlayerExperienceChange(currentExperience);
    }

    private void ExperienceGained(int experience)
    {
        currentExperience += experience;
        // check if we're ready to level up
        while (currentExperience >= GlobalConstants.experienceToLevelUp)
        {
            currentExperience -= GlobalConstants.experienceToLevelUp;
            currentLevel++;
            GameEventsManager.Instance.playerEvents.PlayerLevelChange(currentLevel);
        }
        GameEventsManager.Instance.playerEvents.PlayerExperienceChange(currentExperience);
    }

    private void MoneyGained(int money)
    {
        currentMoney += money;
        GameEventsManager.Instance.playerEvents.MoneyChange(currentMoney);
    }
}
