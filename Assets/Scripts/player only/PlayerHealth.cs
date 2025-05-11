using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Image healthBar;
    public GameObject gameoverPanel;
    public AudioSource backgroundMusic;

    public TextMeshProUGUI healthText;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
        UpdatedHealthText();

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
        UpdatedHealthText();
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
        UpdatedHealthText();
    }

    public void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = (float)currentHealth / maxHealth;
        }
    }
    public void UpdatedHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth + "/" + maxHealth;
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
