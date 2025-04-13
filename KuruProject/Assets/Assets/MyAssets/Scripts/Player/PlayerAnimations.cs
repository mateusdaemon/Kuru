using System;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;

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
    }

    private void UnregisterEvents()
    {
        PlayerEvents.OnAimStarted -= OnAimStart;
        PlayerEvents.OnAimCanceled -= OnAimEnd;
        PlayerEvents.OnAttackStarted -= OnAttackStart;
        PlayerEvents.OnAttackCanceled -= OnAttackEnd;
    }

    private void OnAimStart()
    {
        playerAnimator.SetBool("Draw", true);
    }

    private void OnAimEnd()
    {
        playerAnimator.SetBool("Draw", false);
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

    private void OnPlayerMove(Vector3 direction, bool sprint)
    {
        playerAnimator.SetFloat("PosX", direction.x);
        playerAnimator.SetFloat("PosY", direction.z);
        playerAnimator.SetBool("Sprint", sprint);
    }
}
