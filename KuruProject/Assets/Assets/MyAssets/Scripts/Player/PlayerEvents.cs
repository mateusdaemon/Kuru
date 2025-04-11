using System;
using UnityEngine;

public static class PlayerEvents
{
    public static event Action OnAimStarted;
    public static event Action OnAimCanceled;
    public static event Action OnAttackStarted;
    public static event Action OnAttackCanceled;

    public static void AimStarted() => OnAimStarted?.Invoke();
    public static void AimCanceled() => OnAimCanceled?.Invoke();
    public static void AttackStarted() => OnAttackStarted?.Invoke();
    public static void AttackCanceled() => OnAttackCanceled?.Invoke();
}
