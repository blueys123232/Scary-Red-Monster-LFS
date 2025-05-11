using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHurt : MonoBehaviour
{
    private Transform player;
    public float damage = 6f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V)) 
        {
            damPlayer();
        }

    }

    void damPlayer()
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
