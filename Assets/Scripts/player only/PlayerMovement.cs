using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 10f; // Movement speed
    [SerializeField] private float runSpeed = 20f; // Running speed
    [SerializeField] private float crouchSpeed = 5f; // Crouch speed
    [SerializeField] private float jumpForce = 15f; // Jump force

    [Header("Healing")]
    [SerializeField] private int healAmount = 50; //how much potions heal



    //[Header("Trail Renenderer")]
    //[SerializeField] private TrailRenderer tr;
    [Header("Audio Clips")]
    [SerializeField] public AudioSource Jumpsound;

    [Header("Ground Check")]
    [SerializeField] Transform groundCheck; // Ground check position
    [SerializeField] LayerMask groundLayer; // Layer mask for ground

    [Header("Input Actions")]
    [SerializeField] private InputActionReference moveAction, jumpAction;
    [SerializeField] private InputActionReference runAction;
    [SerializeField] private InputActionReference crouchAction;
    [SerializeField] private InputActionReference healAction;
    [SerializeField] private InputActionReference dashAction;

    [Header("Bools")]
    public bool isRunningPM = false;
    private bool isGrounded;
    private bool isCrouching;
    private bool isTakingDamage;
    private bool CanDash = true;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    private bool isDashing;



    private PlayerHealth playerHealth;
    private PickUpmanager puManager;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 moveDirection; // For capturing horizontal input
    private shootScript S_Script;
    private WeaponStats wStats;
    private PlayerStamina playerStamina;


    void Start()
    {
        // Get required components
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerHealth = GetComponent<PlayerHealth>();
        //find components on other objects
        puManager = FindAnyObjectByType<PickUpmanager>();
        S_Script = FindAnyObjectByType<shootScript>();
        wStats = FindAnyObjectByType<WeaponStats>();
        playerStamina = FindAnyObjectByType<PlayerStamina>();
        // Check for component assignments
        if (rb == null) Debug.LogError("Rigidbody2D component not found on " + gameObject.name);
        if (animator == null) Debug.LogError("Animator component not found on " + gameObject.name);
        if (groundCheck == null) Debug.LogError("GroundCheck Transform not assigned in the Inspector on " + gameObject.name);


    }
    private void OnEnable()
    {
        moveAction.action.Enable();
        jumpAction.action.Enable();
        runAction.action.Enable();
        crouchAction.action.Enable();
        healAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
        jumpAction.action.Disable();
        runAction.action.Disable();
        crouchAction.action.Disable();
        healAction.action.Disable();
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

        // Handle movement input
        Vector2 movementInput = moveAction.action.ReadValue<Vector2>();
        moveDirection = movementInput;

        // Handle crouch input
        isCrouching = crouchAction.action.IsPressed();
        if (animator != null)
        {
            animator.SetBool("isCrouching", isCrouching);
        }

        //isDashing = dashAction.action.IsPressed() && CanDash;
        //if (animator != null)
        //{
        //    StartCoroutine(Dash());
        //    animator.SetBool("isDashing", isDashing);
        //}

        // Handle running input
        isRunningPM = runAction.action.IsPressed();
        if (animator != null)
        {
            animator.SetBool("isRunning", isRunningPM);
        }
        // Handle jump input (space bar and W key)
        if (jumpAction.action.WasPressedThisFrame() && isGrounded)
        {
            if (Jumpsound != null)
            {
                Jumpsound.Play();
            }

            Jump();
        }
    }

    public void Move()
    {

        wStats = FindAnyObjectByType<WeaponStats>();
        S_Script = FindAnyObjectByType<shootScript>();
        // Set the movement speed based on the current state
        float speed = isCrouching ? crouchSpeed : (isRunningPM ? runSpeed : moveSpeed);

        // Flip character sprite based on movement direction
        if (moveDirection.x < 0)
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
        else if (moveDirection.x > 0)
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
            rb.linearVelocity = new Vector2(moveDirection.x * speed, rb.linearVelocity.y);
        }
    }

    public void Jump()
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

    private void UpdateAnimations()
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
        animator.SetBool("isCrouching", isCrouching);

        if (S_Script != null)
        {
            animator.SetInteger("WeaponInt", wStats.wepInt);
        }
        else
        {
            animator.SetInteger("WeaponInt", 0);
        }

        if (playerHealth != null)
            animator.SetBool("isTakingDamage", playerHealth.isTakingDamage);

        //animator.SetBool("isFiring", S_Script.weaponFired);

        animator.SetInteger("WeaponInt", wStats.wepInt);

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
    public void HealPlayer()
    {
        // Click the Healing Potion on any Slot
        //can only use potions if we have more than 0
        if (healAction.action.WasPressedThisFrame() && puManager.hPotCount > 0 && playerHealth.currentHealth < playerHealth.maxHealth)
        {
            puManager.UsePotion();
            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount);
            }
        }
    }
}
//    private IEnumerator Dash()
//    {
//        CanDash = false;
//        isDashing = true;
//        float originalGravity = rb.gravityScale;
//        rb.linearVelocity = new Vector2(transform.localScale.x * dashingPower, 0f);
//        tr.emitting = true;
//        yield return new WaitForSeconds(dashingTime);
//        tr.emitting = false;
//        rb.gravityScale = originalGravity;
//        isDashing = false;
//        yield return new WaitForSeconds(dashingCooldown);
//        CanDash = true;
//    }
//}