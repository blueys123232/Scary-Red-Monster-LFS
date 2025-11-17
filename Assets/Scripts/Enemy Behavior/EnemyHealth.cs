using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Health Settings")]

    public float maxHealth = 100f;
    public float currentHealth;
    private int maxHealth = 50;
    public int currentHealth;



    [Header("Health Bar UI")]
    public Image healthBarFill;
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }


    public void TakeDamage(float amount)
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
            
    }

    void UpdateHealthBar()
    {
        if (healthBarFill != null)
        {
            float fillValue = currentHealth / maxHealth;
            healthBarFill.fillAmount = fillValue;
        }
        else
        {
            Debug.LogWarning("Health Bar Fill is not assigned in EnemyHealth for " + gameObject.name);
        }
            
    }

    void Die()
    {
        Destroy(gameObject);
    }
}