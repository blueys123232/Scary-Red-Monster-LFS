using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 100;
    public int currentHealth;

    [Header("UI")]
    public Image healthBar;
    public GameObject gameoverPanel;
    public TextMeshProUGUI healthText;

    [Header("Audio")]
    public AudioSource backgroundMusic;
    public AudioSource hurtSound;

    [Header("State")]
    public bool isTakingDamage;

    GameManagerScript gameManagerScript;

    private Animator animator;

    private int respawnAmount;

    void Start()
    {
        respawnAmount = 3;
        gameManagerScript = FindAnyObjectByType<GameManagerScript>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        isTakingDamage = false;
        UpdateHealthBar();
        UpdatedHealthText();

        if (gameoverPanel != null)
        {
            gameoverPanel.SetActive(false);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        isTakingDamage = true;

        // Play hurt sound when damaged
        if (hurtSound != null)
        {
            hurtSound.Play();
        }

        UpdateHealthBar();
        UpdatedHealthText();
        CheckIfDead();

        StartCoroutine(DamageReset());

        //ResetDamageState();

    }
    public void ResetDamageState()
    {
        //animator.SetBool("isTakingDamage", false);
        isTakingDamage = false;
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
            gameManagerScript.RespawnPlayer();
            currentHealth = 50;
            UpdateHealthBar();
            UpdatedHealthText();
            respawnAmount -= 1;
        }

        if (respawnAmount == 0)
        {
            ShowGameOverPanel();
        }
    }

    public void ShowGameOverPanel()
    {
        if (backgroundMusic != null && backgroundMusic.isPlaying)
        {
            backgroundMusic.Stop();
        }

        if (gameoverPanel != null)
        {
            gameoverPanel.SetActive(true);
        }
    }

    public IEnumerator DamageReset()
    {
        yield return new WaitForSeconds(0.05f);
        isTakingDamage = false;
    }
}