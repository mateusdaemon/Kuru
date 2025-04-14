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
            PlayerStateMachine.SetState(PlayerState.Idle);
            PlayerEvents.AttackCanceled();
        }
    }

    public static void TryStartAim()
    {
        PlayerStateMachine.SetState(PlayerState.Aiming);
        PlayerEvents.AimStarted();
    }

    public static void TryEndAim()
    {
        PlayerStateMachine.SetState(PlayerState.Idle);
        PlayerEvents.AimCanceled();
    }
}
