using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiranhaBehaviour : MonoBehaviour
{
    PatrolPointScript ppScript;
    SharedBehaviour sbScript;
    //public and private
    //these will probably change later
    [SerializeField] private float speed = 6f;
    [SerializeField] private float damage = 2f;

    private float detectionRange = 5f;
    private float attackRange = 1f;

    private Rigidbody2D rb2D;
    private Animator animator;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").transform;
        ppScript = GetComponent<PatrolPointScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //void Follow
}
