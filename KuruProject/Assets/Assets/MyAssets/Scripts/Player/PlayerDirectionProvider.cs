using UnityEngine;
using UnityEngine.Windows;

public class PlayerDirectionProvider : MonoBehaviour
{
    public Vector3 PlayerDirection { get; private set; }
    public bool PlayerSprint { get; private set; }

    public void SetDirection(Vector2 input, Vector3 camForward, Vector3 camRight, float sprint)
    {
        Vector3 moveDirection = (camForward * input.y + camRight * input.x).normalized;
        PlayerDirection = transform.InverseTransformDirection(moveDirection);
        PlayerSprint = sprint > 0;
    }
}
