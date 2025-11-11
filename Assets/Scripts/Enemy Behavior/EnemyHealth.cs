using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Health Settings")]
    private int maxHealth = 50;
    public int currentHealth;

    //int = whole number (1, 2, 5, 7 etc)
    //double = decimal number (1.3, 5.4, etc)
    //float = both (1, 2, 3, 5.7, 6.3, 1.2)

    [Header("Health Bar UI")]
    public Image healthBarFill;
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth < 0)
            currentHealth = 0;

        UpdateHealthBar();

        if (currentHealth <= 0)
            Die();
    }
    
   void UpdateHealthBar()
    {
        if (healthBarFill != null)
            healthBarFill.fillAmount = currentHealth / maxHealth;
    }
    
    void Die()
    {
        Destroy(gameObject);
    }
}
