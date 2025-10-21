using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedBehaviour : MonoBehaviour
{
    PatrolPointScript ppScript;

    [SerializeField] private float speed = 2f;
    [SerializeField] private float detectionRange = 5f;
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private int damage = 10;
    [SerializeField] private float attackCooldown = 1.0f; // Cooldown time between attacks

    private Rigidbody2D rb;
    private Transform player;
    private Animator animator;

    private float lastAttackTime = 0;
    private bool IsAttacking = false;

    FlipEnemy flipE;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
        flipE = GetComponent<FlipEnemy>();
        ppScript = GetComponent<PatrolPointScript>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, player.position) <= detectionRange)
        {
            if(Vector2.Distance(transform.position, player.position) <= attackRange)
            {
                AttackPlayer();
            }
            else
            {
                FollowPlayer();
            }
        }

        else
        {
            ppScript.Patrol();
        }
    }

    void FollowPlayer()
    {
        Vector2 moveDirection = (player.position - transform.position).normalized;
        rb.velocity = new Vector2(moveDirection.x * speed, rb.velocity.y); // Move towards the Player

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
            animator.SetBool("IsAttacking", true);

            PlayerHealth pHealth = player.GetComponent<PlayerHealth>();
            if(pHealth != null)
            {
                pHealth.TakeDamage(damage);
            }

            StartCoroutine(resetAttack());
        }
    }

    IEnumerator resetAttack()
    {
        yield return new WaitForSeconds(attackCooldown);
        IsAttacking = false;
        animator.SetBool("IsAttacking", false);
    }
}
