using System;
using UnityEngine;

public class CollectTrashQuestStep : QuestStep
{
    private int trashCollected = 0;
    private int trashToComplete = 10;

    private void Start()
    {
        UpdateState();
    }

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
            UpdateState();
        }
        if (trashCollected >= trashToComplete)
        {
            FinishQuestStep();
        }
    }

    private void UpdateState()
    {
        string state = trashCollected.ToString();
        string status = "Terambil " + trashCollected + " / " + trashToComplete + " Sampah.";
        ChangeState(state, status);
        Debug.Log(status);
    }

    protected override void SetQuestStepState(string state)
    {
        this.trashCollected = System.Int32.Parse(state);
        UpdateState();
    }
}
