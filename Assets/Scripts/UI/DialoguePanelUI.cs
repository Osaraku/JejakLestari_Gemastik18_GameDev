using UnityEngine;
using TMPro;
using System.Xml.Serialization;
using Ink.Runtime;
using System.Collections.Generic;

public class DialoguePanelUI : MonoBehaviour
{
    [SerializeField] private GameObject visual;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private DialogueChoiceButton[] choiceButtons;

    private void Awake()
    {
        Hide();
        ResetPanel();
    }

    private void OnEnable()
    {
        GameEventsManager.Instance.dialogueEvents.onDialogueStarted += DialogueStarted;
        GameEventsManager.Instance.dialogueEvents.onDialogueFinished += DialogueFinished;
        GameEventsManager.Instance.dialogueEvents.onDisplayDialogue += DisplayDialogue;
    }

    private void OnDisable()
    {
        GameEventsManager.Instance.dialogueEvents.onDialogueStarted -= DialogueStarted;
        GameEventsManager.Instance.dialogueEvents.onDialogueFinished -= DialogueFinished;
        GameEventsManager.Instance.dialogueEvents.onDisplayDialogue -= DisplayDialogue;
    }

    private void DialogueStarted()
    {
        Show();
    }

    private void DisplayDialogue(string dialogueLine, List<Choice> dialogueChoices)
    {
        dialogueText.text = dialogueLine;

        if (dialogueChoices.Count > choiceButtons.Length)
        {
            Debug.LogError("Too much dialogue choices (more than 4)");
        }

        foreach (DialogueChoiceButton choiceButton in choiceButtons)
        {
            choiceButton.gameObject.SetActive(false);
        }

        int choiceButtonIndex = dialogueChoices.Count - 1;
        for (int inkChoiceIndex = 0; inkChoiceIndex < dialogueChoices.Count; inkChoiceIndex++)
        {
            Choice dialogueChoice = dialogueChoices[inkChoiceIndex];
            DialogueChoiceButton choiceButton = choiceButtons[choiceButtonIndex];

            choiceButton.gameObject.SetActive(true);
            choiceButton.SetChoiceText(dialogueChoice.text);
            choiceButton.SetChoiceIndex(inkChoiceIndex);

            if (inkChoiceIndex == 0)
            {
                choiceButton.SelectButton();
            }

            choiceButtonIndex--;
        }
    }

    private void ResetPanel()
    {
        dialogueText.text = "";
    }

    private void DialogueFinished()
    {
        Hide();
        ResetPanel();
    }

    private void Show()
    {
        visual.SetActive(true);
    }

    private void Hide()
    {
        visual.SetActive(false);
    }
}
