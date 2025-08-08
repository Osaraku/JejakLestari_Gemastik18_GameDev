using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueChoiceButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI choiceText;

    private int choiceIndex = -1;

    private void Start()
    {
        button.onClick.AddListener(HandleClick);
    }

    public void SetChoiceText(string choiceTextString)
    {
        choiceText.text = choiceTextString;
    }

    public void SetChoiceIndex(int choiceIndex)
    {
        this.choiceIndex = choiceIndex;
    }

    public void SelectButton()
    {
        button.Select();
    }

    public void HandleClick()
    {
        GameEventsManager.Instance.dialogueEvents.UpdateChoiceIndex(choiceIndex);
        GameEventsManager.Instance.inputEvents.ClickPressed();
    }
}
