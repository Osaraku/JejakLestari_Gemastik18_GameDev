using System;
using UnityEngine;

public class NPCInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator animator;
    [SerializeField] private string npcName;
    [SerializeField] private string interactText;

    private static int isIdlingHash = Animator.StringToHash("isIdling");
    private static int isTalkingHash = Animator.StringToHash("isTalking");

    private void Awake()
    {
    }

    public void Interact()
    {
        animator.SetBool(isTalkingHash, true);
        GameEventsManager.Instance.npcEvents.NPCInteracted(npcName);
    }

    public string GetInteractText()
    {
        return interactText;
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public string GetNPCName()
    {
        return npcName;
    }
}
