using System;
using UnityEngine;

public class HelpAnimalQuestStep1 : QuestStep
{
    [SerializeField] string npcName = "Pa Wahyu";

    void OnEnable()
    {
        GameEventsManager.Instance.npcEvents.onNPCInteracted += NPCInteracted;
    }

    void OnDisable()
    {
        GameEventsManager.Instance.npcEvents.onNPCInteracted -= NPCInteracted;
    }

    private void NPCInteracted(string name)
    {
        if (name == npcName)
        {
            FinishQuestStep();
        }
    }

    protected override void SetQuestStepState(string state)
    {
        // No Quest State
    }
}
