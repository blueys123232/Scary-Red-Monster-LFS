using Pathfinding;
using System;
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
    [SerializeField] SpriteRenderer spR;
    [SerializeField] Sprite stopSprite;    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb2D = GetComponent<Rigidbody2D>();
        startingPos = transform.position;
        newPos = startingPos;

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
        
        if (playerInRange == true)
        {
            if (seeker.IsDone())
            {
                seeker.StartPath(rb2D.position, GameObject.FindWithTag("Player").transform.position, OnPathComplete);
            }
        }

        else if (!playerInRange)
        {
            if (seeker.IsDone())
            {
                seeker.StartPath(rb2D.position, startingPos, OnPathComplete);
            }
        }

    }

    void OnPathComplete(Pathfinding.Path p)
    {
        if(p.error == false)
        {
            path = p;
            currentWP = 0;

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

        if (path.IsDone())
        {
           //Look into this and see if it can be used in implementing the stop animation.
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWP] - rb2D.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb2D.AddForce(force);

        float distance = Vector2.Distance(rb2D.position, path.vectorPath[currentWP]);

        if(distance < nextWPDist)
        {
            currentWP++;
        }

        //Flip enemy sprite based on Direction
        if (force.x >= 0.01f)
        {
            GFX.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (force.x <= -0.01f)
        {
            GFX.localScale = new Vector3(1f, 1f, 1f);
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
}
