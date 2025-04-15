using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{
    public static void TryStartAttack()
    {
        if (PlayerStateMachine.CurrentState == PlayerState.Aiming)
        {
            PlayerStateMachine.SetState(PlayerState.Charging);
            PlayerEvents.AttackStarted();
        }
    }

    public static void TryEndAttack()
    {
        if (PlayerStateMachine.CurrentState == PlayerState.Charging)
        {
            PlayerStateMachine.SetState(PlayerState.None);
            PlayerEvents.AttackCanceled();
        }
    }

    public static void TryStartAim()
    {
        if (PlayerStateMachine.CurrentState != PlayerState.Aiming &&
            PlayerStateMachine.CurrentState != PlayerState.Charging &&
            PlayerStateMachine.CurrentState != PlayerState.Jumping)
        {
            PlayerStateMachine.SetState(PlayerState.Aiming);
            PlayerEvents.AimStarted();
        }
    }

    public static void TryEndAim()
    {
        PlayerEvents.AimCanceled();
        PlayerStateMachine.SetState(PlayerState.None);
    }

    public static void TryGoIdle()
    {
        if (PlayerStateMachine.CurrentState != PlayerState.Idle &&
            PlayerStateMachine.CurrentState != PlayerState.Aiming &&
            PlayerStateMachine.CurrentState != PlayerState.Charging)
        {
            PlayerStateMachine.SetState(PlayerState.Idle);
        }
    }

    public static void TryToMove()
    {
        if (PlayerStateMachine.CurrentState != PlayerState.Aiming &&
            PlayerStateMachine.CurrentState != PlayerState.Charging &&
            PlayerStateMachine.CurrentState != PlayerState.Jumping)
        {
            PlayerStateMachine.SetState(PlayerState.Moving);
            PlayerEvents.PlayerMove();
        }
    }

    public static void TryToJump()
    {
        PlayerStateMachine.SetState(PlayerState.Jumping);
        PlayerEvents.AimCanceled();
        PlayerEvents.PlayerJump();
    }

    internal static void StopJump()
    {
        PlayerStateMachine.SetState(PlayerState.None);
    }
}
