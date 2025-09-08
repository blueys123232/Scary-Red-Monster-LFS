using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{

    public Rigidbody2D rb;
    WeaponStats wStats;

    [SerializeField] private float ActiveTime;

    // Start is called before the first frame update
    void Start()
    {
        wStats = FindAnyObjectByType<WeaponStats>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * wStats.ProjectileSpeed;

        ActiveTime -= Time.deltaTime;

        if (ActiveTime <= 0f)
        {
            Destroy(gameObject);
        }
    }
}