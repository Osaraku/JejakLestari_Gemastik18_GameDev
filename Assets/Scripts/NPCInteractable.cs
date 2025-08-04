using System;
using UnityEngine;

public class NPCInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator animator;
    [SerializeField] private string interactText;

    private static int isIdlingHash = Animator.StringToHash("isIdling");
    private static int isTalkingHash = Animator.StringToHash("isTalking");

    private void Awake()
    {
    }

    public void Interact()
    {
        animator.SetBool(isTalkingHash, true);
    }

    public string GetInteractText()
    {
        return interactText;
    }

    public Transform GetTransform()
    {
        return transform;
    }
}
