using UnityEngine;

public class MiniToasterBehavior : MonoBehaviour
{
    public float speed = 2f;
    public float detectionRange = 5f;
    public float attackRange = 1f;
    public int damage = 10;
    public Transform[] patrolPoints;

    private int currentPatrolIndex = 0;
    private Transform player;
    private bool isChasing = true;
    private Rigidbody2D rb;
    private float attackCooldown = 1.0f; // Cooldown time between attacks
    private float lastAttackTime = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }

        if (isChasing && distanceToPlayer > attackRange)
        {
            ChasePlayer();
        }
        else if (isChasing && distanceToPlayer <= attackRange)
        {
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                AttackPlayer();
                lastAttackTime = Time.time;
            }
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        if (patrolPoints.Length == 0)
            return;

        Transform targetPoint = patrolPoints[currentPatrolIndex];
        Vector2 targetPosition = new Vector2(targetPoint.position.x, transform.position.y); // Ensure it stays on the ground

        rb.MovePosition(Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime));

        if (Vector2.Distance(transform.position, targetPosition) < 0.2f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
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
