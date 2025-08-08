using UnityEngine;
using TMPro;

public class QuestLogUI : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] TextMeshProUGUI questNameText;
    [SerializeField] TextMeshProUGUI questStatusText;
    [SerializeField] TextMeshProUGUI reputationRewardsText;

    public void Initialize(Quest quest)
    {
        this.questNameText.text = quest.info.displayName;
        this.questStatusText.text = quest.GetFullStatusText();
        this.reputationRewardsText.text = "Reputasi : " + quest.info.experienceReward;
    }
}
