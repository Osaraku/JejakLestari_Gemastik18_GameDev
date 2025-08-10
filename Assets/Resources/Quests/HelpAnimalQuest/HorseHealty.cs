using System;
using UnityEngine;

public class HorseHealty : MonoBehaviour
{

    private void OnEnable()
    {
        GameEventsManager.Instance.questEvents.onQuestStateChange += QuestStateChange;
    }

    private void OnDisable()
    {
        GameEventsManager.Instance.questEvents.onQuestStateChange -= QuestStateChange;
    }

    private void QuestStateChange(Quest quest)
    {
        if (quest.info.id == "HelpAnimalQuest" && quest.state.Equals(QuestState.FINISHED))
        {
            Vector3 currentEulerAngles = transform.rotation.eulerAngles;

            transform.rotation = Quaternion.Euler(currentEulerAngles.x, currentEulerAngles.y, 0f);
        }
    }
}
