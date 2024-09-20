using System.Collections;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public float delayBeforeFall = 2f; // Delay before the key starts falling
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // Initially, no gravity
        StartCoroutine(StartFalling());
    }

    private IEnumerator StartFalling()
    {
        yield return new WaitForSeconds(delayBeforeFall);
        rb.gravityScale = 10; // Set gravity scale to 10 after the delay
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Key collided with the ground.");
            rb.velocity = Vector2.zero; // Stop the key's movement
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Handle any ongoing collision logic here
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Key stopped colliding with the ground.");
        }
    }
}
