using System.Collections.Generic;
using UnityEngine;

public class ProjectileAmmoBehaviour : MonoBehaviour
{

    public Rigidbody2D rb;
    WeaponStats wStats;

    [SerializeField] private float ActiveTime;


    // Start is called before the first frame update
    void Start()
    {
        wStats = FindAnyObjectByType<WeaponStats>();
        rb = GetComponent<Rigidbody2D>();

        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), GameObject.Find("Player").GetComponent<Collider2D>(), true);
        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("Projectile").GetComponent<Collider2D>(), true);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            EnemyHealth eHealth = collision.collider.GetComponent<EnemyHealth>();
            if (eHealth != null && wStats != null)
            {
                eHealth.TakeDamage(wStats.Damage);
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.CompareTag("Tilemap") || collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Pickup"))
        {
            Destroy(gameObject);
        }

        

    }
}