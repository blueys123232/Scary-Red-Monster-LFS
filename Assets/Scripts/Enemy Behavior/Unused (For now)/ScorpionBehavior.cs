using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionBehaviour : MonoBehaviour
{
    PatrolPointScript ppScript; // Reference to PatrolPointScript
    FlipEnemy flipE;
    // Public and Private 
    public float speed = 6f;
    public int damage = 6;

    private float detectonRange = 3f;
    private float attackRange = 1.5f;

    private Rigidbody2D rb;
    private Animator animator;
    private Transform player;

    
    public float damageCooldown = 1f;
    private float damageCooldowntime = 2f;

    private bool IsAttacking = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").transform;
        ppScript = GetComponent<PatrolPointScript>();
        flipE = GetComponent<FlipEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the Player is within detection range
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
        rb.linearVelocity = new Vector2(moveDirection.x * speed, rb.linearVelocity.y); // Move towards the Player

        // Flip direction based of the Player position (if needed)
        if (moveDirection.x > 0 && transform.localScale.x < 0)
        {
            flipE.FlipDirection();
        }
        else if (moveDirection.x < 0 && transform.localScale.x > 0)
        {
            flipE.FlipDirection();
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
}