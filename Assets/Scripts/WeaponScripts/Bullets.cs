using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{

    public int Damage;
    public float projectileSpeed;
    public Rigidbody2D rb;

    [SerializeField] private float ActiveTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * projectileSpeed;

        ActiveTime -= Time.deltaTime;

        if (ActiveTime <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
