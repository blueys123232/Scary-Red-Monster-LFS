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
        player = GameObject.FindWithTag("Player").transform;
        ppScript = GetComponent <PatrolPointScript>();
        flipE = GetComponent<FlipEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
