using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    private Transform player;
    private Vector2 originalPos;
    [SerializeField] private float detectionRange = 35f;
    public float moveSpeed = 2;
    public bool isPlayerInRange;

    private void Awake()
    {
        //get the enemies original position
        originalPos = gameObject.transform.position;
        player = GameObject.FindWithTag("Player").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        isPlayerInRange = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}

