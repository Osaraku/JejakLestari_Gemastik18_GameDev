using System;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float animationBlendSpeed = 10f;

    private PlayerController playerController;
    private PlayerState playerState;

    private static int isMovingHash = Animator.StringToHash("isMoving");
    private static int isSprintingHash = Animator.StringToHash("isSprinting");

    private Vector3 currentBlendInput = Vector3.zero;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        playerState = GetComponent<PlayerState>();
    }

    private void Update()
    {
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (playerState.currentPlayerMovementState == PlayerMovementState.Idling)
        {
            animator.SetBool(isMovingHash, false);
        }

        if (playerState.currentPlayerMovementState == PlayerMovementState.Running)
        {
            animator.SetBool(isMovingHash, true);
        }

        if (playerState.currentPlayerMovementState == PlayerMovementState.Sprinting)
        {
            animator.SetBool(isMovingHash, true);
            animator.SetBool(isSprintingHash, true);
        }
        else
        {
            animator.SetBool(isSprintingHash, false);
        }

    }
}
