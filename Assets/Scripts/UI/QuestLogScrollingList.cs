using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestLogScrollingList : MonoBehaviour
{
    [SerializeField] private GameObject contentParent;
    [SerializeField] private GameObject questLogTemplatePrefab;

    private Dictionary<string, QuestLogUI> idToTemplateMap = new Dictionary<string, QuestLogUI>();

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
        // Membuat atau memperbarui UI untuk quest
        QuestLogUI questLogUI = CreateUIIfNotExists(quest);

        // Hanya menampilkan quest yang sedang berlangsung atau bisa diselesaikan
        if (quest.state == QuestState.IN_PROGRESS || quest.state == QuestState.CAN_FINISH)
        {
            questLogUI.gameObject.SetActive(true);
        }
        else
        {
            questLogUI.gameObject.SetActive(false);
        }
    }

    public QuestLogUI CreateUIIfNotExists(Quest quest)
    {
        QuestLogUI questLogUI = null;

        if (!idToTemplateMap.ContainsKey(quest.info.id))
        {
            questLogUI = InstantiateQuestLogUI(quest);
        }
        else
        {
            questLogUI = idToTemplateMap[quest.info.id];
            // Pastikan untuk memperbarui status quest
            questLogUI.Initialize(quest);
        }

        return questLogUI;
    }

    private QuestLogUI InstantiateQuestLogUI(Quest quest)
    {
        QuestLogUI questLogUI = Instantiate(questLogTemplatePrefab, contentParent.transform).GetComponent<QuestLogUI>();
        questLogUI.gameObject.name = quest.info.id + "_UI";
        questLogUI.Initialize(quest);
        idToTemplateMap[quest.info.id] = questLogUI;
        return questLogUI;
    }
}
