using UnityEngine;

public class MiniToasterBehaviour : MonoBehaviour
{
    PatrolPointScript ppScript;

    private float speed = 2f;
    private float detectionRange = 5f;
    private float attackRange = 1f;
    private int damage = 10;

    private Transform player;
    private Rigidbody2D rb;
    private float attackCooldown = 1.0f; // Cooldown time between attacks
    private float lastAttackTime = 0;

    FlipEnemy flipE;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        ppScript = GetComponent<PatrolPointScript>();
        flipE = GetComponent<FlipEnemy>();
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            FollowPlayer();
        }

        else if (distanceToPlayer <= attackRange)
        {
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                AttackPlayer();
                lastAttackTime = Time.time;
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

    void ChasePlayer()
    {
        Vector2 targetPosition = new Vector2(player.position.x, transform.position.y); // Ensure it stays on the ground
        rb.MovePosition(Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime));
    }

    void AttackPlayer()
    {
        // Assuming the player has a script with a method called TakeDamage(int damage)
        player.GetComponent<PlayerHealth>().TakeDamage(damage);
    }
}
