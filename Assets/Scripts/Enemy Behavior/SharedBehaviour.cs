using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedBehaviour : MonoBehaviour
{
    PatrolPointScript ppScript;
    EnemyDetection enemyDetectionScript;
    FlipEnemy flipE;

    //All these variables can be adjusted in the inspector so each enemy type can be customised
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private int damage = 10;
    [SerializeField] private float attackCooldown = 1.0f; // Cooldown time between attacks

    private Rigidbody2D rb;
    private Transform player;
    private Animator animator;
    private float lastAttackTime = 0;
    private bool IsAttacking = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
        flipE = GetComponent<FlipEnemy>();
        ppScript = GetComponent<PatrolPointScript>();
        animator = GetComponent<Animator>();
        enemyDetectionScript = GetComponent<EnemyDetection>();
    }

    // Update is called once per frame
    void Update()
    {
        //using the boolean from EnemyDetection check if player is in Range
        if (enemyDetectionScript.isPlayerInRange)
        {
            //if its in range and is close enough attack
            //otherwise continue following
            if (Vector2.Distance(transform.position, player.position) <= attackRange)
            {
                AttackPlayer();
            }
            else
            {
                FollowPlayer();
            }
        }
        //if player is outside of the follow range then go back on to patrol
        else
        {
            ppScript.Patrol();
        }
    }

    void FollowPlayer()
    {
        Vector2 moveDirection = (player.position - transform.position).normalized;
        rb.velocity = new Vector2(moveDirection.x * enemyDetectionScript.moveSpeed, rb.velocity.y); // Move towards the Player

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
        //if enemy hasnt already attacked then attack 
        if (!IsAttacking)
        {
            //set isAttacking true so there can  a cooldown
            IsAttacking = true;
            animator.SetBool("IsAttacking", true);

            //access player health and use the TakeDamage function to remove amount of health
            //Damage to health is determined by Enemy by a variable in the inspector
            PlayerHealth pHealth = player.GetComponent<PlayerHealth>();
            if (pHealth != null)
            {
                pHealth.TakeDamage(damage);
            }

            //One enemy has attacked activate this coroutine to reset attack bool so enemy is able to attack again
            StartCoroutine(resetAttack());
        }
    }

    IEnumerator resetAttack()
    {
        //use the attack cooldown variable to determine how long before enemy can attack again
        yield return new WaitForSeconds(attackCooldown);
        IsAttacking = false;
        animator.SetBool("IsAttacking", false);
    }


}