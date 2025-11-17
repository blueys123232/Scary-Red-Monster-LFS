using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class BossHealthBar : MonoBehaviour
{

    // Start is called before the first frame update
    [Header("Boss Health Settings")]
    public float maxHealth = 100f;
    public float currentHealth;

    [Header("UI elements")]
    public Image bossHealthBarfill;
    public TextMeshProUGUI bossNameText;
    [Tooltip("The Displayed name of the boss (e.g., TOKIPOK'")]
    public string bossName = "BOSS: UNKNOWN";

    [Header("Defeat Settings")]
    public string bossDefeatedScene = "";
    public float delayBeforeSceneLoad = 3f;

    private bool isDefeated = false;
    void Start()
    {
        currentHealth = maxHealth;

        if (bossNameText != null)
            bossNameText.text = bossName.ToUpper();

        UpdateHealthBar();
    }

    public void TakeDamage(float amount)
    {
        if (isDefeated) return;
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            StartCoroutine(DefeatBoss());
        }

    }

    void UpdateHealthBar()
    {
        if (bossHealthBarfill != null)
        {

            bossHealthBarfill.fillAmount = currentHealth / maxHealth;
        }
    }
    private System.Collections.IEnumerator DefeatBoss()
    {
        isDefeated = true;

        Debug.Log($"{bossName} Has been defeated!");

        yield return new WaitForSeconds(delayBeforeSceneLoad);

        if (!string.IsNullOrEmpty(bossDefeatedScene))
        {
            SceneManager.LoadScene(bossDefeatedScene);
        }
        else
        {
            Debug.LogWarning("No boss Defeat Scene - staying in current scene.");
        }
    }
}

