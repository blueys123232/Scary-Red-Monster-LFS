using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallDelay = 1.0f; // Time before the platform starts falling

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the player steps on the platform, start the fall process
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", fallDelay); // Call the Fall method after a delay
        }
    }

    void Fall()
    {
        rb.isKinematic = false; // Allow the platform to be affected by physics (start falling)
        rb.gravityScale = 1; // Enable gravity on the platform

        // Platform will fall but won't be destroyed
        // Destroy(gameObject, destroyDelay); // This line is removed/commented out
    }
}
