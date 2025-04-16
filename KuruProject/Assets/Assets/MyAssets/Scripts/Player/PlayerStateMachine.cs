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
    Jumping,
    Interacting
}

public enum PlayerCondition
{
    None,
    CanCollect
}

public class PlayerStateMachine : MonoBehaviour
{
    public static PlayerState CurrentState { get; private set; } = PlayerState.Idle;
    public static PlayerCondition CurrentCondition { get; private set; } = PlayerCondition.None;

    private void Update()
    {
        Debug.Log(CurrentState.ToString());
    }

    public static void SetState(PlayerState state)
    {
        CurrentState = state;
    }

    public static void SetCondition(PlayerCondition condition)
    {
        CurrentCondition = condition;
    }
}
