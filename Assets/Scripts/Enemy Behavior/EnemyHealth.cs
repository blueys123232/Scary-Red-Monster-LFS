using NUnit.Framework.Internal.Filters;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [Header("Enemy Health Settings")]
    public float maxHealth = 100f;
    public float currentHealth;
    bool damaged;
    [SerializeField] private TextMeshPro damageNumber;

    private void Start()
    {
        damageNumber.text = "";
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        damageNumber.text = amount.ToString();
        damageNumber.color = Color.red;
        Instantiate(damageNumber, new Vector3(this.transform.position.x, this.transform.position.y + 0.7f), Quaternion.identity);
        damaged = true;
    }

    private void Update()
    {
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} has been defeated!");
        Destroy(gameObject);
    }
}