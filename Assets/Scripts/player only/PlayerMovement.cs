using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f; // Movement speed
    public float runSpeed = 20f; // Running speed
    public float crouchSpeed = 5f; // Crouch speed
    public float jumpForce = 15f; // Jump force
    public Transform groundCheck; // Ground check position
    public LayerMask groundLayer; // Layer mask for ground

    private Rigidbody2D rb;
    private Animator animator;
    private PlayerStamina playerStamina;
    private bool isGrounded;
    private bool isCrouching;
    private bool isRunning;
    private float moveDirection; // For capturing horizontal input

    void Start()
    {
        // Get required components
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerStamina = GetComponent<PlayerStamina>();

        // Check for component assignments
        if (rb == null) Debug.LogError("Rigidbody2D component not found on " + gameObject.name);
        if (animator == null) Debug.LogError("Animator component not found on " + gameObject.name);
        if (playerStamina == null) Debug.LogError("PlayerStamina component not found on " + gameObject.name);
        if (groundCheck == null) Debug.LogError("GroundCheck Transform not assigned in the Inspector on " + gameObject.name);
    }

    void Update()
    {
        HandleInput();
        UpdateAnimations();
    }

    void FixedUpdate()
    {
        Move();
    }

    void HandleInput()
    {
        if (playerStamina == null)
        {
            Debug.LogError("PlayerStamina component is not assigned.");
            return;
        }

        // Handle movement input
        moveDirection = Input.GetAxisRaw("Horizontal");

        // Handle crouch input
        isCrouching = Input.GetKey(KeyCode.S);
        if (animator != null)
        {
            animator.SetBool("isCrouching", isCrouching);
        }

        // Handle running input
        isRunning = Input.GetKey(KeyCode.LeftShift) && playerStamina.currentStamina > 0;
        playerStamina.SetRunning(isRunning);

        // Handle jump input (space bar and W key)
        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W)) && isGrounded)
        {
            Jump();
        }
    }

    void Move()
    {
        // Set the movement speed based on the current state
        float speed = isCrouching ? crouchSpeed : (isRunning ? runSpeed : moveSpeed);

        // Flip character sprite based on movement direction
        if (moveDirection < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (moveDirection > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        // Apply horizontal velocity
        if (rb != null)
        {
            rb.velocity = new Vector2(moveDirection * speed, rb.velocity.y);
        }
    }

    void Jump()
    {
        if (groundCheck == null)
        {
            Debug.LogError("GroundCheck Transform is not assigned.");
            return;
        }

        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        // Apply vertical velocity for jumping
        if (isGrounded)
        {
            if (rb != null)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce); // y velocity for jumping
            }
        }
    }

    void UpdateAnimations()
    {
        if (animator == null)
        {
            Debug.LogError("Animator component is not assigned.");
            return;
        }

        // Update animator parameters for movement and jumping
        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);
        animator.SetBool("isJumping", !isGrounded);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player is on the ground
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the player is off the ground
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            isGrounded = false;
        }
    }
}
