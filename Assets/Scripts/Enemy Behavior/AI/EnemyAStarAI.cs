using Pathfinding;
using System;
using System.Collections;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyAStarAI : MonoBehaviour
{
    //WP = Waypoint

    public UnityEngine.Transform GFX;
    [SerializeField] BoxCollider2D detectRange;

    [SerializeField] private float speed = 10f;
    [SerializeField] private float nextWPDist = 3f;

    Pathfinding.Path path;
    int currentWP = 0;
    public bool reachedEndOfPath = false;
    bool playerInRange = false;
    Seeker seeker;
    Rigidbody2D rb2D;

    private Vector2 startingPos, newPos;
    [SerializeField] private Animator anim;

    //Variables for damaging players
    private bool IsAttacking = false;

    private bool returntoStartPosition = false;
    private bool hasStopped = false;
    private UnityEngine.Transform player;
    //All these variables can be adjusted in the inspector so each enemy type can be customised
    [Header("Attack Settings")]
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private int damage = 10;
    [SerializeField] private float attackCooldown = 1.0f; // Cooldown time between attacks


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb2D = GetComponent<Rigidbody2D>();
        startingPos = transform.position;
        newPos = startingPos;
        player = GameObject.FindWithTag("Player").transform;

        InvokeRepeating("UpdatePath", 0f, .5f);
        InvokeRepeating("changeNewPos", 0f, 5f);

        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GameObject.Find("Spikes").GetComponent<Collider2D>());
        if (anim == null) Debug.LogError("Animator component not found");
    }

    void changeNewPos()
    {
        newPos = new Vector2(UnityEngine.Random.Range(startingPos.x - 3f, startingPos.x + 3f), startingPos.y);
        startingPos = newPos;
    }

    void UpdatePath()
    {
        if (seeker == null || rb2D == null)
            return;

        if (playerInRange == true)
        {
            if (seeker.IsDone())
            {

                returntoStartPosition = false;
                hasStopped = false;


                if (anim != null)
                {
                    anim.SetBool("returntoStartPosition", false);
                }

                {
                    anim.SetBool("hasStopped", false);
                }

                seeker.StartPath(rb2D.position, GameObject.FindWithTag("Player").transform.position, OnPathComplete);
                LookAt2D(player);

            }
        }
        if (seeker.IsDone() && player != null)
        {
            seeker.StartPath(rb2D.position, player.position, OnPathComplete);
        }
    


        else if (!playerInRange)
        {

            returntoStartPosition = true;

            if (anim != null)
            {
                anim.SetBool("returntoStartPosition", true);
            }

            if (seeker.IsDone())
            {

                seeker.StartPath(rb2D.position, startingPos, OnPathComplete);

            }

        }

    }

    void OnPathComplete(Pathfinding.Path p)
    {
        if (p.error == false)
        {
            path = p;
            currentWP = 0;


            reachedEndOfPath = false;
            hasStopped = false;
            if (anim != null)
            {
                anim.SetBool("returntoStartPosition", false);
            }

            {
                anim.SetBool("hasStopped", false);
            }

        }
    }

    private void Update()
    {
        //using the boolean from EnemyDetection check if player is in Range
        if (playerInRange)
        {
            //if its in range and is close enough attack
            //otherwise continue following
            if (Vector2.Distance(transform.position, player.position) <= attackRange)
            {
                AttackPlayer();
            }
        }
    }
    void FixedUpdate()
    {
        if (path == null)
            return;


        if (currentWP >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWP] - rb2D.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb2D.AddForce(force);

        float distance = Vector2.Distance(rb2D.position, path.vectorPath[currentWP]);

        if (distance < nextWPDist)
        {
            currentWP++;
        }

        //Flip enemy sprite based on Direction
        if (force.x >= 0.01f)
        {
            GFX.localScale = new Vector3(-GFX.localScale.x, GFX.localScale.y, 1f);
        }
        else if (force.x <= -0.01f)
        {
            GFX.localScale = new Vector3(GFX.localScale.x, GFX.localScale.y, 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            anim.SetBool("playerInRange", playerInRange);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            anim.SetBool("playerInRange", playerInRange);
        }
    }

    void AttackPlayer()
    {
        //if enemy hasnt already attacked then attack 
        if (!IsAttacking)
        {
            //set isAttacking true so there can  a cooldown
            IsAttacking = true;

            anim.SetBool("IsAttacking", true);

            //animator.SetBool("IsAttacking", true);


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



        anim.SetBool("IsAttacking", false);

        //animator.SetBool("IsAttacking", false);

    }

    void LookAt2D(UnityEngine.Transform Target)
    {

        if (Target == null)
            return;

 

        //Unity has no inbuilt Lookat2D function so made one for us to use
        //Made it so can give it a different target when we call it 

        //Gets the direction of our target
        var dir = (Vector2)Target.position - (Vector2)transform.position;
        //Gets the angle of our target in Radians, that we then convert to Degrees
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;


        Quaternion newRot = Quaternion.Euler(Vector3.forward * angle);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRot, 15f * Time.deltaTime);
    }

}


