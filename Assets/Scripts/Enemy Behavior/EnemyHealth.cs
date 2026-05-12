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
    // Start is called before the first frame update
    //[Header("Health Bar UI")]
    //public Image healthBarImage;
    private void Start()
    {
        currentHealth = maxHealth;
       //UpdateHealthBar();
    }

    public IEnumerator TakeDamage(float amount, float delay)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        damageNumber.text = amount.ToString();
        yield return new WaitForSeconds(delay);
        damageNumber.text = "";
    }

    private void Update()
    {
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    //private void UpdateHealthBar()
    //{
    //    if (healthBarImage != null)
    //    {
    //        float fillValue = currentHealth / maxHealth;
    //        healthBarImage.fillAmount = fillValue;
    //    }
    //    else
    //    {
    //        Debug.LogWarning("Health Bar Fill is not assigned in EnemyHealth for " + gameObject.name);
    //    }
    //}

    private void Die()
    {
        Debug.Log($"{gameObject.name} has been defeated!");
        Destroy(gameObject);
    }
}