using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehavior : MonoBehaviour
{
    public float speed = 2f;
    public float detectionRange = 5f;
    public float attackRange = 1.5f;

    private Animator animator;
    private Rigidbody2D rb;
    private Transform player;


    private bool isAttacking = false;

    PatrolPointScript ppScript;
    FlipEnemy flipE;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").transform; // assmuning the player is tagged "Player"
        ppScript = GetComponent<PatrolPointScript>(); //GetThePatrolPointScript
        flipE = GetComponent<FlipEnemy>(); // Get The FlipEnemyScript
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
            if (distanceToPlayer <= detectionRange)
            {
                if (distanceToPlayer <= attackRange)
                {
                    AttackPlayer();
                }
                // OtherWise Follow the Player
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
        rb.velocity = new Vector2(moveDirection.x * speed, rb.velocity.y);

        animator.SetBool("isWalking", true);
        flipE.FlipDirection();  // Flip to face the player
    }
    void AttackPlayer()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            animator.SetTrigger("isAttacking");




            StartCoroutine(ResetAttack());

        }

    }

    private IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(1f);
        isAttacking = false;
    }
}