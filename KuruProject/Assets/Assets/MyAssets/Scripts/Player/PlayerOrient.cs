using UnityEngine;
using UnityEngine.Windows;

public class PlayerOrient : MonoBehaviour
{
    public void Orient(Vector2 input, Vector3 camForward, Vector3 camRight)
    {
        if (input.sqrMagnitude < 0.01f) return;

        Vector3 targetDirection = (camForward * input.y + camRight * input.x).normalized;

        Quaternion toRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, 0.15f);
    }

    public void OrientShoot(Vector3 camForward, Vector3 camRight)
    {
        //Vector3 targetDirection = (camForward + camRight).normalized;
        Vector3 targetDirection = camForward;

        Quaternion toRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, 1f);
    }
}
