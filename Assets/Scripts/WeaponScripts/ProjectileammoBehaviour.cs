using System.Collections.Generic;
using UnityEngine;

public class ProjectileAmmoBehaviour : MonoBehaviour
{

    public Rigidbody2D rb;
    RangerWeaponStats RwStats;

    [SerializeField] private float ActiveTime;

    // Start is called before the first frame update
    void Start()
    {
        RwStats = FindAnyObjectByType<RangerWeaponStats>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = transform.right * RwStats.ProjectileSpeed;

        ActiveTime -= Time.deltaTime;

        if (ActiveTime <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            EnemyHealth eHealth = collision.collider.GetComponent<EnemyHealth>();
            if (eHealth != null && RwStats != null)
            {
                eHealth.TakeDamage(RwStats.Damage);
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.CompareTag("Tilemap") || collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Pickup"))
        {
            Destroy(gameObject);
        }

    }
}