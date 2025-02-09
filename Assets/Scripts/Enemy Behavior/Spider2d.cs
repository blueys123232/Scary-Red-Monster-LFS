using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider2d : MonoBehaviour
{
    // the public and private starts
    public float speed = 2f;
    public Transform[] patrolPoints;
    private int currentPatrolPoint = 0;
    public float damage = 6f;

    public float detectionRange = 5f;
    public float attackRange = 1.5f;

    private Rigidbody2D rb;
    private Animator animator;
    private Transform player;


    private bool canTakeDamage = true;
    public float damageCooldown = 1f;
    private float damageCooldownTimer = 0f;


    // the new biting bool
    private bool isBiting = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!canTakeDamage)
        {

            damageCooldownTimer += Time.deltaTime;
            if (damageCooldownTimer >= damageCooldown)
            {
                canTakeDamage = true;
                damageCooldownTimer = 0f;
            }

        }

        if (Vector2.Distance(transform.position, player.position) <= detectionRange)
        {

            if (Vector2.Distance(transform.position, player.position) <= attackRange)
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
            Patrol();
        }
    }
    void Patrol()
    {


        Transform target = patrolPoints[currentPatrolPoint];

        Vector2 targetPosition = target.position;
        Vector2 moveDirection = (targetPosition - (Vector2)transform.position).normalized;

        rb.velocity = new Vector2(moveDirection.x * speed, rb.velocity.y);

        if (moveDirection.x > 0 && transform.localScale.x < 0) // facing right and left 
        {
            Debug.Log("flipping the right");
            FlipDirection();
        }
        else if (moveDirection.x < 0 && transform.localScale.x > 0) // facing left and right
        {
            Debug.Log("flipping the Left");
            FlipDirection();
        }

        if (Vector2.Distance(transform.position, targetPosition) < 0.1f) //  
        {
            // Flips The Direction of the Enemy 
            FlipDirection();
      
            currentPatrolPoint = (currentPatrolPoint + 1) % patrolPoints.Length;
        }

    }

    void FollowPlayer()
    {
        Vector2 moveDirection = (player.position - transform.position).normalized;
        rb.velocity = new Vector2(moveDirection.x * speed, rb.velocity.y);

        // flip the image of the player's position 
        if (moveDirection.x > 0 && transform.localScale.x < 0) // facing right and left 
        {
            Debug.Log("flipping the Right");
            FlipDirection();
        }
        else if (moveDirection.x < 0 && transform.localScale.x > 0) // facing left and right
        {
            Debug.Log("flipping the Left");
            FlipDirection();
        }

    }
    void FlipDirection()
    {
        Vector3 scale = transform.localScale;
        scale.x = -scale.x;
        transform.localScale = scale;
    }

    void AttackPlayer()
    {
        if (!isBiting)
        {
            isBiting = true;
            animator.SetBool("isBiting", true);

            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }




            StartCoroutine(ResetBiting());
        }
    }

IEnumerator ResetBiting()

{
   // apply the new reset Biting in the whole code 
    yield return new WaitForSeconds(0.5f);
    isBiting = false;
    animator.SetBool("isBiting", false);
}
    

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // If the spider collides with the player
        {
            // Apply damage to the player if they're within range and we collide
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage); // Apply the 6 damage
            }
            // after taking the damage, and it starts the cooldown
            canTakeDamage = false;
            damageCooldownTimer = 0f;
        }
    }

}