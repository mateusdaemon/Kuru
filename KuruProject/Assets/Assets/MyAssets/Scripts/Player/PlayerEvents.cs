using System;
using UnityEngine;

public static class PlayerEvents
{
    public static event Action OnAimStarted;
    public static event Action OnAimCanceled;
    public static event Action OnAttackStarted;
    public static event Action OnAttackCanceled;
    public static event Action<Vector3, bool> OnPlayerMove;

    public static void AimStarted() => OnAimStarted?.Invoke();
    public static void AimCanceled() => OnAimCanceled?.Invoke();
    public static void AttackStarted() => OnAttackStarted?.Invoke();
    public static void AttackCanceled() => OnAttackCanceled?.Invoke();
    public static void PlayerMove(Vector3 direction, bool sprint) => OnPlayerMove?.Invoke(direction, sprint);
}
