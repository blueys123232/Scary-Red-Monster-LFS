using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 10f; // Movement speed
    [SerializeField] private float runSpeed = 20f; // Running speed
    [SerializeField] private float crouchSpeed = 5f; // Crouch speed
    [SerializeField] private float jumpForce = 15f; // Jump force
    [SerializeField] private int healAmount = 50; //how much potions heal

    [SerializeField] Transform groundCheck; // Ground check position
    [SerializeField] LayerMask groundLayer; // Layer mask for ground

    private PlayerHealth playerHealth;
    private PickUpmanager puManager;

    private Rigidbody2D rb;
    private Animator animator;
    private PlayerStamina playerStamina;
    private bool isGrounded;
    private bool isCrouching;
    private bool isRunningPM;
    private float moveDirection; // For capturing horizontal input
    private bool isTakingDamage; 
    private shootScript S_Script;
    private RangerWeaponStats RwStats;



    void Start()
    {
        // Get required components
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerStamina = GetComponent<PlayerStamina>();
        playerHealth = GetComponent<PlayerHealth>();
        //find components on other objects
        puManager = FindAnyObjectByType<PickUpmanager>();
        S_Script = FindAnyObjectByType<shootScript>();
        RwStats = FindAnyObjectByType<RangerWeaponStats>();
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
        HealPlayer();

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
        isRunningPM = Input.GetKey(KeyCode.LeftShift) && playerStamina.currentStamina > 0;

        if(isRunningPM && moveDirection > 0)
        {
            playerStamina.SetRunning(isRunningPM);
        } 
        //else if (!isRunningPM)
        //{
        //    playerStamina.SetRunning(!isRunningPM);
        //}


        // Handle jump input (space bar and W key)
        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W)) && isGrounded)
        {
            Jump();
        }
    }

    void Move()
    {
        S_Script = FindAnyObjectByType<shootScript>();

        // Set the movement speed based on the current state
        float speed = isCrouching ? crouchSpeed : (isRunningPM ? runSpeed : moveSpeed);

        // Flip character sprite based on movement direction
        if (moveDirection < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);

            if (S_Script == null)
            {
                //Debug.Log("Carry on");
            }
            else if (S_Script != null)
            {
                S_Script.firePoint.transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }
        }
        else if (moveDirection > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            if (S_Script == null)
            {
                //Debug.Log("Carry on");
            }
            else if (S_Script != null)
            {
                S_Script.firePoint.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
        }

        // Apply horizontal velocity
        if (rb != null)
        {
            rb.linearVelocity = new Vector2(moveDirection * speed, rb.linearVelocity.y);
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
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // y velocity for jumping
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
        animator.SetFloat("xVelocity", Mathf.Abs(rb.linearVelocity.x));
        animator.SetFloat("yVelocity", rb.linearVelocity.y);
        animator.SetBool("isJumping", !isGrounded);


        if (S_Script != null)
        {
            animator.SetInteger("WeaponInt", RwStats.RwepInt);
        }
        else
        {
            animator.SetInteger("WeaponInt", 0);
        }

        if (playerHealth != null)
            animator.SetBool("isTakingDamage", playerHealth.isTakingDamage);

        if (RwStats.RwType == RangerWeaponType.None)
        {
            animator.SetBool("isFiring", false);
        }
        else
        {
            animator.SetBool("isFiring", S_Script.weaponFired);
        }

        animator.SetInteger("WeaponInt", RwStats.RwepInt);
        //Debug.Log(RwStats.RwepInt);
        //Debug.Log(RwStats.RwType);

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
    void HealPlayer()
    {
        // Click the Healing Potion on any Slot
        //can only use potions if we have more than 0
        if (Input.GetKeyDown(KeyCode.H) && puManager.hPotCount > 0 && playerHealth.currentHealth < playerHealth.maxHealth)
        {
            puManager.UsePotion();
            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount);
            }
        }
    }

}