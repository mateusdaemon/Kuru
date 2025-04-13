using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody rb;
    private bool hasHit = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!hasHit && rb.linearVelocity.sqrMagnitude > 0.1f)
        {
            transform.forward = rb.linearVelocity.normalized;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hasHit) return;
        hasHit = true;

        rb.linearVelocity = Vector3.zero;
        rb.useGravity = false;
        rb.isKinematic = true;

        // Gruda no ponto de contato
        ContactPoint contact = collision.contacts[0];
        transform.position = contact.point;
        transform.parent = collision.transform; // agora a flecha acompanha o objeto, se ele se mover
    }
}
