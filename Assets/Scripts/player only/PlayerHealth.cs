using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Image healthBar;
    public GameObject gameoverPanel;
    public AudioSource backgroundMusic;

    

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();

        if (gameoverPanel != null)
        {
            gameoverPanel.SetActive(false);
        }
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
            ShowGameOverPanel();
        }
    }

    public void ShowGameOverPanel()
    {
        if (backgroundMusic != null && backgroundMusic)
        {
            backgroundMusic.Stop();
        }

        if (gameoverPanel != null)
        {
            gameoverPanel.SetActive(true);
        }
    }
}
