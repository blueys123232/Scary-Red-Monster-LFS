using System.Collections.Generic;
using UnityEngine;

public class ProjectileAmmoBehaviour : MonoBehaviour
{

    public Rigidbody2D rb;
    WeaponStats wStats;
    EnemyHealth eHealth;

    [SerializeField] private float ActiveTime;

    // Start is called before the first frame update
    void Start()
    {
        eHealth = FindAnyObjectByType<EnemyHealth>();
        wStats = FindAnyObjectByType<WeaponStats>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = transform.right * wStats.ProjectileSpeed;

        ActiveTime -= Time.deltaTime;

        if (ActiveTime <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth eHealth = collision.GetComponent<EnemyHealth>();
            if (eHealth != null && wStats != null)
            {
                eHealth.TakeDamage(wStats.Damage);
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.CompareTag("Tilemap"))
        {
            Destroy(gameObject);

        }
    }
}