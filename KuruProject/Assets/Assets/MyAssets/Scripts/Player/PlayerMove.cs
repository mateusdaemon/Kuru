using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float sprintSpeed = 8f;

    public void Move(Vector2 input, Vector3 camForward, Vector3 camRight, float sprintInput)
    {
        Vector3 moveDirection = (camForward * input.y + camRight * input.x).normalized;        
        float currentSpeed = sprintInput > 0 ? sprintSpeed : speed;
        Vector3 movement = moveDirection * currentSpeed;
        PlayerActions.TryToMove();
        rigidBody.linearVelocity = new Vector3(movement.x, rigidBody.linearVelocity.y, movement.z);
    }
}
