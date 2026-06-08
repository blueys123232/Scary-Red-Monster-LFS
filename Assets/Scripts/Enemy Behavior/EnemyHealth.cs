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
    [SerializeField] private TextMeshPro damageNumber;
    private void Start()
    {
        damageNumber.text = "";
        currentHealth = maxHealth;
    }

    public IEnumerator TakeDamage(float amount, float delay)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        damageNumber.text = amount.ToString();
        yield return new WaitForSeconds(0.5f);
        damageNumber.text = "";
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