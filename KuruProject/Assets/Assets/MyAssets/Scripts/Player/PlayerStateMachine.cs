using System;
using UnityEngine;
using UnityEngine.Playables;

public enum PlayerState
{
    None,
    Idle,
    Moving,
    Aiming,
    Charging,
    Jumping
}

public class PlayerStateMachine : MonoBehaviour
{
    public static PlayerState CurrentState { get; private set; } = PlayerState.Idle;

    private void Update()
    {
        Debug.Log(CurrentState.ToString());
    }

    public static void SetState(PlayerState state)
    {
        CurrentState = state;
    }
}
