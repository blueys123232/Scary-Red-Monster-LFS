using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    private Transform player;
    private Vector2 originalPos;
    [SerializeField] private float detectionRange = 35f;


    public float moveSpeed;
    public bool isPlayerInRange;

    // Start is called before the first frame update
    void Start()
    {
        //get the enemies original position
        originalPos = transform.position;
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = isPlayerInRange ? player.position : originalPos;
        MoveToPosition(targetPos);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("player in range");
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("player escaped");
            isPlayerInRange = false;
        }
    }

    private void MoveToPosition(Vector3 targetPos)
    {
        //calculate direction to the target position
        Vector3 direction = (targetPos - transform.position).normalized;

        //Move towards the target position
        float step = moveSpeed * Time.deltaTime; //calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
    }

    private void OnDrawGizmos()
    {
        //visualize the detection Radius
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
