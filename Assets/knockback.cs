using UnityEngine;

public class ParticleKnockback : MonoBehaviour
{
    public float knockbackForce = 10f;
    public Transform knockbackDirection;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnParticleCollision(GameObject other)
    {
        rb.AddForce(knockbackDirection.right * knockbackForce, ForceMode.Impulse);
    }
}