using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionBehavior : MonoBehaviour
{
    PatrolPointScript ppScript; // Reference to PatrolPointScript
    // Public and Private 
    public float speed = 6f;
    public float damage = 2f;

    public float detectonRange = 5f;
    public float attackRange = 1.5f;

    private Rigidbody2D rb;
    private Animator animator;
    private Transform player;

    private bool canTakeDamage = true;
    public float damageCooldown = 1f;
    private float damageCooldowntime = 0f;

    private bool IsAttacking = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").transform;
        ppScript = GetComponent<PatrolPointScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the Plaer is within detection range
        if (Vector2.Distance(transform.position, player.position) <= detectonRange)
        {
            // If Within attack range, attack the player
            if (Vector2.Distance(transform.position, player.position) <= attackRange)
            {
                AttackPlayer();
            }
            // Ohterwise Follow the Player ]
            else
            {
                FollowPlayer();
            }
        }


        else
        {
            ppScript.Patrol(); // This makes the scoption patrol using the PatrolPointSctipt
        }
    }
    void FollowPlayer()
    {
        Vector2 moveDirection = (player.position - transform.position).normalized;
        rb.velocity = new Vector2(moveDirection.x * speed, rb.velocity.y); // Move towards the Player

        // Flip direction based of the Player position (if needed)
        if (moveDirection.x > 0 && transform.localScale.x < 0)
        {
            FlipDirection();
        }
        else if (moveDirection.x < 0 && transform.localScale.x > 0)
        {
            FlipDirection();
        }
    }

    void AttackPlayer()
    {
        if (!IsAttacking)
        {
            IsAttacking = true;
            animator.SetBool("IsAttacking", true); // Trigger the Attack Animation

            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage); // Apply Damage to tghe Player
            }

            // Reset Attack after the animaton is done
            StartCoroutine(ResetAttack());
        }
    }

    IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(damageCooldowntime); // Wait For attack cooldown
        IsAttacking = false;
        animator.SetBool("IsAttacking", false); // Reset the attack animation 
    }
    void FlipDirection()
    {
        Vector3 scale = transform.localScale;
        scale.x = -scale.x; // Flip the image horizontally by negating the x-axis scale
        transform.localScale = scale;
    }
}