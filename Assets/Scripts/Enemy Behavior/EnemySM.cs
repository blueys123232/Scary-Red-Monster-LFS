using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemySM : MonoBehaviour
{
    private StateMachine Brain;
    private PlayerMovement Player;
    private PlayerHealth pHealth;

    private bool playerNear, canAttack;

    private float AttackCooldown;

    [SerializeField] private int Damage;
    [SerializeField] private float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Brain = GetComponent<StateMachine>();
        Player = FindAnyObjectByType<PlayerMovement>();
        pHealth = FindAnyObjectByType<PlayerHealth>();
        Brain.pushState(Idle, OnIdleEnter);
    }

    // Update is called once per frame
    void Update()
    {
        //if distance between enemy and player is less than 5, playerNear is true
        playerNear = Vector2.Distance(transform.position, Player.transform.position) < 5;
        //as above if player is really close, then canAttack is true
        canAttack = Vector2.Distance(transform.position, Player.transform.position) < 1;
    }

    void OnIdleEnter()
    {
        //Do idle things here
        //this will most likely be where we reset our pathing/movement
    }

    void Idle()
    {
        //default state we enter
        //allows us to move between other states
        //will have checks in here for distance from player & (Hopefully) a random wander/patrol mechanic

        if (playerNear)
        {
            Brain.pushState(Chase, null);
        }
    }

    void Chase()
    {
        //Dont need a onChaseEnter (for now????)
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, Player.transform.position) > 6)
        {
            //leave the chase state machine
            Brain.pushState(Idle, OnIdleEnter);
        }

    }

    void OnPatrolEnter()
    {

    }

    void Patrol()
    {

    }

    void OnAttackEnter()
    {
        //reset movement?
    }

    void Attack()
    {
        AttackCooldown -= Time.deltaTime;
        if(AttackCooldown <= 0)
        {
            //hurt player
            pHealth.TakeDamage(Damage);
            AttackCooldown = 2f;
        }
    }


}
