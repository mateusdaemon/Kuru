using System;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private Transform groundCheckPoint;

    private Rigidbody rb;
    private bool canJump = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void TryJump(float jumpInput)
    {
        if (jumpInput > 0 && IsGrounded() && canJump)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z); // zera y antes de pular
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            canJump = false;
            Invoke(nameof(EnableJump), 0.5f);
            PlayerActions.TryToJump();
        }
    }

    private void EnableJump()
    {
        canJump = true;
        PlayerActions.StopJump();
    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheckPoint.position, groundCheckRadius, groundLayer);
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheckPoint != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(groundCheckPoint.position, groundCheckRadius);
        }
    }
}
