using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private InputSystem_Actions inputActions;

    public float AimShoot { get; private set; }
    public float Attack { get; private set; }
    public Vector2 MoveDirection { get; private set; }
    public float Jump { get; private set; }
    public float Sprint { get; private set; }

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
        RegisterInputEvents();
        inputActions.Enable();
    }

    private void Update()
    {
        MoveDirection = inputActions.Player.Move.ReadValue<Vector2>();
        Jump = inputActions.Player.Jump.ReadValue<float>();
        Sprint = inputActions.Player.Sprint.ReadValue<float>();
        
        if (inputActions.Player.AimShoot.inProgress)
        {
            PlayerActions.TryStartAim();
        }
    }

    private void OnDisable()
    {
        UnregisterInputEvents();
        inputActions.Disable();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void RegisterInputEvents()
    {
        inputActions.Player.AimShoot.performed += OnAimShootStarted;
        inputActions.Player.AimShoot.canceled += OnAimShootCancel;
        inputActions.Player.Attack.performed += OnAttackStarted;
        inputActions.Player.Attack.canceled += OnAttackCanceled;

        inputActions.Player.Interact.performed += OnInteractStart;
        inputActions.Player.Interact.canceled += OnInteractEnd;
    }

    private void UnregisterInputEvents()
    {
        inputActions.Player.AimShoot.performed -= OnAimShootStarted;
        inputActions.Player.AimShoot.canceled -= OnAimShootCancel;
        inputActions.Player.Attack.performed -= OnAttackStarted;
        inputActions.Player.Attack.canceled -= OnAttackCanceled;

        inputActions.Player.Interact.performed -= OnInteractStart;
        inputActions.Player.Interact.canceled -= OnInteractEnd;
    }

    private void OnAimShootStarted(InputAction.CallbackContext ctx)
    {
        PlayerActions.TryStartAim();
    }

    private void OnAimShootCancel(InputAction.CallbackContext ctx)
    {
        PlayerActions.TryEndAim();
    }

    private void OnAttackStarted(InputAction.CallbackContext ctx)
    {
        PlayerActions.TryStartAttack();
    }

    private void OnAttackCanceled(InputAction.CallbackContext ctx)
    {
        PlayerActions.TryEndAttack();
    }

    private void OnInteractStart(InputAction.CallbackContext context)
    {
        PlayerActions.TryToInteract();
    }

    private void OnInteractEnd(InputAction.CallbackContext context)
    {
        PlayerActions.StopInteract();
    }
}
