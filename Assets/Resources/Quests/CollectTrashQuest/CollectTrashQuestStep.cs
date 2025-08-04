using System;
using UnityEngine;

public class CollectTrashQuestStep : QuestStep
{
    private int trashCollected = 0;
    private int trashToComplete = 5;

    private void OnEnable()
    {
        GameEventsManager.Instance.trashEvents.onTrashCollected += TrashCollected;
    }

    private void OnDisable()
    {
        GameEventsManager.Instance.trashEvents.onTrashCollected -= TrashCollected;
    }

    private void TrashCollected()
    {
        if (trashCollected < trashToComplete)
        {
            trashCollected++;
            Debug.Log("collected");
        }
        if (trashCollected >= trashToComplete)
        {
            finishQuestStep();
        }
    }
}
