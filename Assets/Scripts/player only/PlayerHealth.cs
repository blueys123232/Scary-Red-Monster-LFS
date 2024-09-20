using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Image healthBar;

    // The name of the scene to load when the player dies
    public string sceneToLoadOnDeath; // Any scene name you want to load when the player dies

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= Mathf.RoundToInt(damage);
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        UpdateHealthBar();
        CheckIfDead();
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = (float)currentHealth / maxHealth;
        }
    }

    public void CheckIfDead()
    {
        if (currentHealth <= 0)
        {
            // Load the scene specified in the inspector when the player dies
            LoadSceneOnDeath();
        }
    }

    public void LoadSceneOnDeath()
    {
        // If a scene name is set, load that scene
        if (!string.IsNullOrEmpty(sceneToLoadOnDeath))
        {
            SceneManager.LoadScene(sceneToLoadOnDeath);
        }
        else
        {
            Debug.LogWarning("No scene specified to load on death.");
        }
    }
}
