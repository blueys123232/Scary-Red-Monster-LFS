using System;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using Pathfinding;

public class EnemyAStarAI : MonoBehaviour
{
    //WP = Waypoint

    [SerializeField] private Transform target;

    [SerializeField] private float speed = 10f;
    [SerializeField] private float nextWPDist = 3f;

    Pathfinding.Path path;
    int currentWP = 0;
    bool reachedEndOfPath = false;
    bool playerInRange = false;
    Seeker seeker;
    Rigidbody2D rb2D;

    [SerializeField] BoxCollider2D detectRange;
    public Vector2 startingPos;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb2D = GetComponent<Rigidbody2D>();
        startingPos = transform.position;

        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void UpdatePath()
    {
        if (playerInRange == true)
        {
            if (seeker.IsDone())
            {
                seeker.StartPath(rb2D.position, target.position, OnPathComplete);
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

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
            return;

        if(currentWP >= path.vectorPath.Count)
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

        if(distance < nextWPDist)
        {
            currentWP++;
        }
    }

    private void Update()
    {
        if (!playerInRange)
        {
            transform.position = startingPos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
