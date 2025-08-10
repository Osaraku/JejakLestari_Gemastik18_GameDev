using System;

public class PlayerEvents
{
    public event Action<bool> onPlayerMovementLock;
    public void PlayerMovementLock(bool isLocked)
    {
        if (onPlayerMovementLock != null)
        {
            onPlayerMovementLock(isLocked);
        }
    }

    public event Action<int> onMoneyGained;
    public void MoneyGained(int money)
    {
        if (onMoneyGained != null)
        {
            onMoneyGained(money);
        }
    }

    public event Action<int> onMoneyChange;
    public void MoneyChange(int money)
    {
        if (onMoneyChange != null)
        {
            onMoneyChange(money);
        }
    }

    public event Action<int> onExperienceGained;
    public void ExperienceGained(int experience)
    {
        if (onExperienceGained != null)
        {
            onExperienceGained(experience);
        }
    }

    public event Action<int> onPlayerLevelChange;
    public void PlayerLevelChange(int level)
    {
        if (onPlayerLevelChange != null)
        {
            onPlayerLevelChange(level);
        }
    }

    public event Action<int> onPlayerExperienceChange;
    public void PlayerExperienceChange(int experience)
    {
        if (onPlayerExperienceChange != null)
        {
            onPlayerExperienceChange(experience);
        }
    }

    public event Action onPlayerModeChangeToBoat;
    public void PlayerModeChangeToBoat()
    {
        if (onPlayerModeChangeToBoat != null)
        {
            onPlayerModeChangeToBoat();
        }
    }

    public event Action onPlayerModeChangeToHuman;
    public void PlayerModeChangeToHuman()
    {
        if (onPlayerModeChangeToHuman != null)
        {
            onPlayerModeChangeToHuman();
        }
    }
}
