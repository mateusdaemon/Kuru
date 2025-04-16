using System;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;
    [SerializeField] PlayerDirectionProvider playerDirectionProvider;

    private void OnEnable()
    {
        RegisterEvents();
    }

    private void OnDisable()
    {
        UnregisterEvents();
    }

    private void RegisterEvents()
    {
        PlayerEvents.OnAimStarted += OnAimStart;
        PlayerEvents.OnAimCanceled += OnAimEnd;
        PlayerEvents.OnAttackStarted += OnAttackStart;
        PlayerEvents.OnAttackCanceled += OnAttackEnd;
        PlayerEvents.OnPlayerMove += OnPlayerMove;
        PlayerEvents.OnPlayerJump += OnPlayerJump;
        PlayerEvents.OnPlayerInteract += OnPlayerInteract;
    }

    private void UnregisterEvents()
    {
        PlayerEvents.OnAimStarted -= OnAimStart;
        PlayerEvents.OnAimCanceled -= OnAimEnd;
        PlayerEvents.OnAttackStarted -= OnAttackStart;
        PlayerEvents.OnAttackCanceled -= OnAttackEnd;
        PlayerEvents.OnPlayerMove -= OnPlayerMove;
        PlayerEvents.OnPlayerJump -= OnPlayerJump;
        PlayerEvents.OnPlayerInteract -= OnPlayerInteract;
    }

    private void OnAimStart()
    {
        playerAnimator.SetBool("Draw", true);
    }

    private void OnAimEnd()
    {
        playerAnimator.SetBool("Draw", false);
        playerAnimator.SetBool("Charge", false);
    }

    private void OnAttackStart()
    {
        playerAnimator.SetBool("Charge", true);
    }

    private void OnAttackEnd()
    {
        playerAnimator.SetBool("Charge", false);
        playerAnimator.SetTrigger("Shoot");
    }

    private void OnPlayerMove()
    {
        playerAnimator.SetFloat("PosX", playerDirectionProvider.PlayerDirection.x);
        playerAnimator.SetFloat("PosY", playerDirectionProvider.PlayerDirection.z);
        playerAnimator.SetBool("Sprint", playerDirectionProvider.PlayerSprint);
    }

    private void OnPlayerJump()
    {
        playerAnimator.SetTrigger("Jump");
    }

    private void OnPlayerInteract()
    {
        playerAnimator.SetTrigger("Interact");
    }
}
