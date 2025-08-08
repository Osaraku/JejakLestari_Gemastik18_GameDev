using UnityEngine;

public class QuestJournalUI : MonoBehaviour
{
    [SerializeField] private GameObject Visual;
    [SerializeField] private QuestLogScrollingList scrollingList;

    private void Start()
    {
        Hide();
    }

    private void OnEnable()
    {
        GameEventsManager.Instance.questEvents.onQuestStateChange += QuestStateChange;
        GameEventsManager.Instance.cameraEvents.onCameraChangeToFirstPerson += Show;
        GameEventsManager.Instance.cameraEvents.onCameraChangeToThirdPerson += Hide;
    }

    private void OnDisable()
    {
        GameEventsManager.Instance.questEvents.onQuestStateChange -= QuestStateChange;
        GameEventsManager.Instance.cameraEvents.onCameraChangeToFirstPerson -= Show;
        GameEventsManager.Instance.cameraEvents.onCameraChangeToThirdPerson -= Hide;
    }

    private void Show()
    {
        Visual.SetActive(true);
    }

    private void Hide()
    {
        Visual.SetActive(false);
    }

    private void QuestStateChange(Quest quest)
    {
        scrollingList.CreateUIIfNotExists(quest);
    }
}
