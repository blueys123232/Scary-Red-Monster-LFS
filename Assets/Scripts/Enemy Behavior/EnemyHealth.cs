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
    private float textTimer;
    bool damaged;
    [SerializeField] private TextMeshPro damageNumber;

    private void Start()
    {
        textTimer = 10f;
        damageNumber.text = "";
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        damageNumber.text = amount.ToString();
        damaged = true;
    }

    private void Update()
    {
        if (damaged)
        {
            textTimer--;
        }

        if(textTimer <= 0)
        {
            damageNumber.text = "";
            damaged = false;
            textTimer = 10f;
        }

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