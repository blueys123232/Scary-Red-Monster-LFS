using UnityEngine;

public class MeleeHit : MonoBehaviour
{
    WeaponStats weaponStats;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        weaponStats = GetComponentInParent<WeaponStats>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            EnemyHealth e_Health = collision.collider.GetComponent<EnemyHealth>();
            collision.collider.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.forward * 2f, ForceMode2D.Force);
            if (e_Health != null && weaponStats != null)
            {
                StartCoroutine(e_Health.TakeDamage(weaponStats.Damage, 1f));
            }
        }

    }
}
