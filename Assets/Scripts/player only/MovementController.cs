using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;

    public int speed;
    public int runSpeedMultiplier = 2;
    public float jumpForce = 5f;
    public Vector2 moveInput;

    public InputAction moveAction;
    public InputAction jumpAction;
    public InputAction crouchAction;
    public InputAction runAction;

    public bool isRunning = false;
    public bool isGrounded = true;
    public bool isCrouching = false;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        var inputActionAsset = GetComponent<PlayerInput>().actions;
        var playerActionMap = inputActionAsset.FindActionMap("Player");
        moveAction = playerActionMap.FindAction("Movement");
        jumpAction = playerActionMap.FindAction("Jump");
        crouchAction = playerActionMap.FindAction("Crouch");
        runAction = playerActionMap.FindAction("Running");

        moveAction.performed += OnMove;
        moveAction.canceled += OnMove;
        jumpAction.performed += OnJump;
        crouchAction.performed += OnCrouch;
        crouchAction.canceled += OnCrouch;
        runAction.performed += OnRun;
        runAction.canceled += OnRun;
    }

    public void OnEnable()
    {
        moveAction.Enable();
        jumpAction.Enable();
        crouchAction.Enable();
        runAction.Enable();
    }

    public void OnDisable()
    {
        moveAction.Disable();
        jumpAction.Disable();
        crouchAction.Disable();
        runAction.Disable();
    }

    public void FixedUpdate()
    {
        float targetSpeed = speed * moveInput.x * (isRunning ? runSpeedMultiplier : 1);
        rb.velocity = new Vector2(targetSpeed, rb.velocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        // Update animator with movement speed
        animator.SetFloat("xVelocity", moveInput.x);
        animator.SetFloat("yVelocity", rb.velocity.y);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
            animator.SetBool("isJumping", true);
        }
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            // Read value as a float for better control compatibility
            float crouchValue = context.ReadValue<float>();
            if (crouchValue > 0) // Button is pressed
            {
                isCrouching = true;
                animator.SetBool("isCrouching", true);
                Debug.Log("Crouch!");
            }
        }
        else if (context.canceled)
        {
            isCrouching = false;
            animator.SetBool("isCrouching", false);
            Debug.Log("Stop Crouching!");
        }
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isRunning = true;
        }
        else if (context.canceled)
        {
            isRunning = false;
        }
    }

    public void Move(Vector2 direction)
    {
        moveInput = direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
    }
}
