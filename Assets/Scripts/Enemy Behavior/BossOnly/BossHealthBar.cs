using UnityEngine;
using UnityEngine.UI;
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

    [Tooltip("The Displayed name of the boss (e.g., TOXIPOK'")]
    public string bossName = "BOSS: UNKNOWN";

    [Header("Death Animation")]
    private Animator bossAnimator;

    [Tooltip("Assign the complete boss health bar object")]
    public GameObject bossHealthBarObject;

    [Header("Boss Health Setttings")]
    private bool isDefeated = false;
    private bool isBossHealthbarDisabled = false;

    void Start()
    {
        currentHealth = maxHealth;
        bossAnimator = GetComponent<Animator>();
        if (bossNameText != null)
            bossNameText.text = bossName.ToUpper();

        UpdateHealthBar();
    }

    public void TakeDamage(float amount)
    {
        if (isDefeated) return;
        if (amount <= 0) return;
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            DefeatBoss();
        }

    }

    void UpdateHealthBar()
    {
        if (bossHealthBarfill != null)
        {
            return;
        }
        if (maxHealth <= 0f)
        {
            bossHealthBarfill.fillAmount = 0f;
            return;
        }
        bossHealthBarfill.fillAmount = currentHealth / maxHealth;
    }
    private void DefeatBoss()
    {
        // prevent the defeat method from running multiple tiles
        if (isDefeated)
        {
            return;
        }


        isDefeated = true;
        currentHealth = 0f;

        UpdateHealthBar();

        Debug.Log(bossName + " Has been defeated!");

        if (bossAnimator != null)
        {
            bossAnimator.SetBool("isDefeated", true);
        }

        else
        {
            Debug.LogWarning("Boss Animator is not assigned on " + gameObject.name);
        }
    DisableBossHealthBar();
}
private void DisableBossHealthBar()
{
    if (isBossHealthbarDisabled)
    {
        return;
    }

    if (bossHealthBarObject != null)
    {
            bossHealthBarObject.SetActive(false);
    }
    else
    {
        Debug.LogWarning("Boss Health Bar Object is not assigned");
    }

    isBossHealthbarDisabled = true; 

   }
}