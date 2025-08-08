using System;
using UnityEngine;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    [Header("Ink Story")]
    [SerializeField] private TextAsset inkJson;

    private Story story;
    private int currentChoiceIndex = -1;

    private bool dialoguePlaying = false;
    private InkExternalFunctions inkExternalFunctions;
    private InkDialogueVariables inkDialogueVariables;

    private void Awake()
    {
        story = new Story(inkJson.text);
        inkExternalFunctions = new InkExternalFunctions();
        inkExternalFunctions.Bind(story);
        inkDialogueVariables = new InkDialogueVariables(story);
    }

    private void OnDestroy()
    {
        inkExternalFunctions.Unbind(story);
    }

    private void OnEnable()
    {
        GameEventsManager.Instance.dialogueEvents.onEnterDialogue += EnterDialogue;
        GameEventsManager.Instance.dialogueEvents.onUpdateChoiceIndex += UpdateChoiceIndex;
        GameEventsManager.Instance.dialogueEvents.onUpdateInkDialogueVariable += UpdateInkDialogueVariable;
        GameEventsManager.Instance.inputEvents.onSubmitPressed += SubmitPressed;
        GameEventsManager.Instance.inputEvents.onClickPressed += SubmitPressed;
        GameEventsManager.Instance.questEvents.onQuestStateChange += QuestStateChange;
    }


    private void OnDisable()
    {
        GameEventsManager.Instance.dialogueEvents.onEnterDialogue -= EnterDialogue;
        GameEventsManager.Instance.dialogueEvents.onUpdateChoiceIndex -= UpdateChoiceIndex;
        GameEventsManager.Instance.dialogueEvents.onUpdateInkDialogueVariable -= UpdateInkDialogueVariable;
        GameEventsManager.Instance.inputEvents.onSubmitPressed -= SubmitPressed;
        GameEventsManager.Instance.inputEvents.onClickPressed -= SubmitPressed;
        GameEventsManager.Instance.questEvents.onQuestStateChange -= QuestStateChange;
    }

    private void QuestStateChange(Quest quest)
    {
        GameEventsManager.Instance.dialogueEvents.UpdateInkDialogueVariable(quest.info.id + "State", new StringValue(quest.state.ToString()));
    }

    private void UpdateInkDialogueVariable(string name, Ink.Runtime.Object value)
    {
        inkDialogueVariables.UpdateVariableState(name, value);
    }

    private void UpdateChoiceIndex(int choiceIndex)
    {
        this.currentChoiceIndex = choiceIndex;
    }

    private void SubmitPressed(InputEventContext inputEventContext)
    {
        if (!inputEventContext.Equals(InputEventContext.DIALOGUE))
        {
            return;
        }

        ContinueOrExitStory();
    }

    private void EnterDialogue(string knotName)
    {
        if (dialoguePlaying)
        {
            return;
        }

        dialoguePlaying = true;

        GameEventsManager.Instance.dialogueEvents.DialogueStarted();

        GameEventsManager.Instance.cameraEvents.CameraLock(true);
        GameEventsManager.Instance.playerEvents.PlayerMovementLock(true);

        GameEventsManager.Instance.inputEvents.ChangeInputEventContext(InputEventContext.DIALOGUE);

        if (!knotName.Equals(""))
        {
            story.ChoosePathString(knotName);
        }
        else
        {
            Debug.LogError("no knotname");
        }

        inkDialogueVariables.SyncVariablesAndStartListening(story);

        ContinueOrExitStory();
    }

    private void ContinueOrExitStory()
    {
        if (story.currentChoices.Count > 0 && currentChoiceIndex != -1)
        {
            story.ChooseChoiceIndex(currentChoiceIndex);
            currentChoiceIndex = -1;
        }

        if (story.canContinue)
        {
            string dialogueLine = story.Continue();

            while (IsLineBlank(dialogueLine) && story.canContinue)
            {
                dialogueLine = story.Continue();
            }

            if (IsLineBlank(dialogueLine) && !story.canContinue)
            {
                ExitDialogue();
            }
            else
            {
                GameEventsManager.Instance.dialogueEvents.DisplayDialogue(dialogueLine, story.currentChoices);
            }
        }
        else if (story.currentChoices.Count == 0)
        {
            ExitDialogue();
        }
    }

    private void ExitDialogue()
    {
        dialoguePlaying = false;

        GameEventsManager.Instance.dialogueEvents.DialogueFinished();

        GameEventsManager.Instance.cameraEvents.CameraLock(false);
        GameEventsManager.Instance.playerEvents.PlayerMovementLock(false);

        GameEventsManager.Instance.inputEvents.ChangeInputEventContext(InputEventContext.DEFAULT);

        inkDialogueVariables.StopListening(story);

        story.ResetState();
    }

    private bool IsLineBlank(string dialogueLine)
    {
        return dialogueLine.Trim().Equals("") || dialogueLine.Trim().Equals("\n");
    }
}
