using System;
using UnityEngine;
using UnityEngine.Playables;

public enum PlayerState
{
    Idle,
    Moving,
    Aiming,
    Charging,
    Jumping
}

public class PlayerStateMachine : MonoBehaviour
{
    public static PlayerState CurrentState { get; private set; } = PlayerState.Idle;

    private void OnEnable()
    {
        PlayerEvents.OnPlayerJump += OnPlayerJump;
        PlayerEvents.OnPlayerMove += OnPlayerMove;
    }

    private void OnDisable()
    {
        PlayerEvents.OnPlayerJump -= OnPlayerJump;
        PlayerEvents.OnPlayerMove -= OnPlayerMove;
    }

    private void OnPlayerMove(Vector3 dir, bool sprint)
    {
        if (CurrentState == PlayerState.Idle && dir.magnitude > 0.1f)
            CurrentState = PlayerState.Moving;
    }

    private void OnPlayerJump()
    {
        if (CurrentState == PlayerState.Charging)
            PlayerEvents.AttackCanceled(); // Cancela carregamento do tiro

        if (CurrentState == PlayerState.Aiming)
            PlayerEvents.AimCanceled(); // Sai da mira

        CurrentState = PlayerState.Jumping;
    }

    public static void SetState(PlayerState state)
    {
        CurrentState = state;
    }
}
