using System;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private PlayerController playerController;
    private PlayerState playerState;

    private static int isGroundedHash = Animator.StringToHash("isGrounded");
    private static int isIdlingHash = Animator.StringToHash("isIdling");
    private static int isRunningHash = Animator.StringToHash("isRunning");
    private static int isSprintingHash = Animator.StringToHash("isSprinting");
    private static int isJumpingHash = Animator.StringToHash("isJumping");
    private static int isFallingHash = Animator.StringToHash("isFalling");

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
        bool isGrounded = playerController.GetIsGrounded();
        bool isIdling = playerState.currentPlayerMovementState == PlayerMovementState.Idling;
        bool isRunning = playerState.currentPlayerMovementState == PlayerMovementState.Running;
        bool isSprinting = playerState.currentPlayerMovementState == PlayerMovementState.Sprinting;
        bool isJumping = playerState.currentPlayerMovementState == PlayerMovementState.Jumping;
        bool isFalling = playerState.currentPlayerMovementState == PlayerMovementState.Falling;

        animator.SetBool(isGroundedHash, isGrounded);
        animator.SetBool(isIdlingHash, isIdling);
        animator.SetBool(isRunningHash, isRunning);
        animator.SetBool(isSprintingHash, isSprinting);
        animator.SetBool(isJumpingHash, isJumping);
        animator.SetBool(isFallingHash, isFalling);
    }
}
