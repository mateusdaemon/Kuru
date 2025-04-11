using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Components")]
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerMove playerMove;
    [SerializeField] private PlayerOrient playerOrient;
    [SerializeField] private PlayerJump playerJump;
    [SerializeField] private CameraDirectionProvider cameraDirectionProvider;

    void FixedUpdate()
    {
        if (playerInput == null || 
            playerMove == null || 
            playerJump == null || 
            cameraDirectionProvider == null || 
            playerOrient == null) return;

        Vector3 forward = cameraDirectionProvider.GetCameraForward();
        Vector3 right = cameraDirectionProvider.GetCameraRight();

        playerMove.Move(playerInput.MoveDirection, forward, right, playerInput.Sprint);
        playerOrient.Orient(playerInput.MoveDirection, forward, right);
        playerJump.TryJump(playerInput.Jump);
    }

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
    }

    private void UnregisterEvents()
    {
        PlayerEvents.OnAimStarted -= OnAimStart;
        PlayerEvents.OnAimCanceled -= OnAimEnd;
    }

    private void OnAimStart()
    {
        HudManager.Instance.ToggleAimIcon(true);
    }

    private void OnAimEnd()
    {
        HudManager.Instance.ToggleAimIcon(false);
    }
}
