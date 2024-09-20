using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public PlayerHealth pHealth;
    public float damage = 10f;

    // Start is called before the first frame update
    void Start()
    {
        if (pHealth == null)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                pHealth = player.GetComponent<PlayerHealth>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (pHealth != null)
            {
                pHealth.TakeDamage((int)damage); // Cast float to int
            }
        }
    }
}
