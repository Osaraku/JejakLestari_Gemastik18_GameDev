using UnityEngine;

public abstract class QuestStep : MonoBehaviour
{
    private bool isFinished = false;

    protected void finishQuestStep()
    {
        if (!isFinished)
        {
            isFinished = true;

            // TO DO

            Destroy(this.gameObject);
        }
    }
}
