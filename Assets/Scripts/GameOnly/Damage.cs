using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private PlayerHealth pHealth;
    public int damage = 10;

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

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (pHealth != null)
            {
                pHealth.TakeDamage(damage); // Cast float to int
            }
        }
    }
}
