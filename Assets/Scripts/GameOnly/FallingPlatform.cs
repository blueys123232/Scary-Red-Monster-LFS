using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [Header("Falling Platform Settings")]
    public float fallDelay = 1f; // Time before the platform starts falling

    [Tooltip("Extra time before the platform falls if the player leaves it")]
    public float escapeDelay = 0.5f;

    [Tooltip("Hlow long the platform falls before being destroyed")]
    public float destroyDelay = 2f;


    private Rigidbody2D rb;

    private bool playerStanding = false;
    private bool hasStartedFalling = false;
    private bool Fallscheduled = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null) Debug.LogError("RigidBody2D compoment not found" + gameObject.name);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the player steps on the platform, start the fall process
        if (collision.gameObject.CompareTag("Player") && !hasStartedFalling)
        {

            playerStanding = true;


            if (!Fallscheduled)
            {
                Fallscheduled = true;


                Invoke("Fall", fallDelay);
            }
        }
    }  

    private void OnCollisionExit2d(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !hasStartedFalling)
        {
            playerStanding = false;


            CancelInvoke("Fall");



            Invoke("Fall", escapeDelay);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
{
        if (collision.gameObject.CompareTag("Player") && !hasStartedFalling)
        {
            playerStanding = false;

            CancelInvoke("Fall");

            Invoke("Fall", escapeDelay);
        }
    }

    void Fall()
    {
       if (hasStartedFalling || rb == null)
        {
            return;
        }

        hasStartedFalling = true;

        rb.bodyType = RigidbodyType2D.Dynamic; // Allow the platform to be affected by physics (start falling)
        rb.gravityScale = 1; // Enable gravity on the platform

        
        Destroy(gameObject, destroyDelay); 
    }
}
