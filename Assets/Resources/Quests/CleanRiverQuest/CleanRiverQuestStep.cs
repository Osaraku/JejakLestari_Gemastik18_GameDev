using System;
using System.Collections;
using UnityEngine;

public class CleanRiverQuestStep : QuestStep
{
    [SerializeField] private int roverTrashCollected = 0;
    [SerializeField] private int riverTrashToComplete = 3;

    private void Start()
    {
        UpdateState();
    }

    private void OnEnable()
    {
        GameEventsManager.Instance.trashEvents.onRiverTrashCollected += RiverTrashCollected;
    }

    private void OnDisable()
    {
        GameEventsManager.Instance.trashEvents.onRiverTrashCollected -= RiverTrashCollected;
    }

    private void RiverTrashCollected()
    {
        if (roverTrashCollected < riverTrashToComplete)
        {
            roverTrashCollected++;
            UpdateState();
        }
        if (roverTrashCollected >= riverTrashToComplete)
        {
            GameEventsManager.Instance.playerEvents.PlayerModeChangeToHuman();
            StartCoroutine(FinishAfterDelay());
        }
    }

    private void UpdateState()
    {
        string state = roverTrashCollected.ToString();
        string status = "Terambil " + roverTrashCollected + " / " + riverTrashToComplete + " Sampah.";
        ChangeState(state, status);
        Debug.Log(status);

        if (roverTrashCollected == 0)
        {
            GameEventsManager.Instance.playerEvents.PlayerModeChangeToBoat();
        }
    }

    private IEnumerator FinishAfterDelay()
    {
        yield return new WaitForSeconds(1f);

        FinishQuestStep();
    }

    protected override void SetQuestStepState(string state)
    {
        this.roverTrashCollected = System.Int32.Parse(state);
        UpdateState();
    }
}
