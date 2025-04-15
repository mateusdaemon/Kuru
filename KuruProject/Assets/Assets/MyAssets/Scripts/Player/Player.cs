using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Components")]
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerMove playerMove;
    [SerializeField] private PlayerOrient playerOrient;
    [SerializeField] private PlayerJump playerJump;
    [SerializeField] private CameraDirectionProvider cameraDirectionProvider;
    [SerializeField] private PlayerDirectionProvider playerDirectionProvider;

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
        playerDirectionProvider.SetDirection(playerInput.MoveDirection, forward, right, playerInput.Sprint);
        playerJump.TryJump(playerInput.Jump);
    }
}
