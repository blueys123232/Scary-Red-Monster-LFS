using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStamina : MonoBehaviour
{
    public float currentStamina;
    [SerializeField] float maxStamina = 100f;
    [SerializeField] float staminaRegenRate = 5f;
    [SerializeField] float staminaDrainRate = 10f;
    public Image staminaBar;

    public TextMeshProUGUI staminatext;

    private bool isRunning = false;

    void Start()
    {
        currentStamina = maxStamina;
        UpdateStaminaBar();
        UpdateStaminaText();
    }

    void Update()
    {
        HandleStamina();
        UpdateStaminaBar();
        UpdateStaminaText();
    }

    void HandleStamina()
    {
        if (isRunning && currentStamina > 0)
        {
            currentStamina -= staminaDrainRate * Time.deltaTime;
            if (currentStamina < 0)
            {
                currentStamina = 0;
            }
        }
        else if (!isRunning && currentStamina < maxStamina)
        {
            currentStamina += staminaRegenRate * Time.deltaTime;
            if (currentStamina > maxStamina)
            {
                currentStamina = maxStamina;
            }
        }
    }

    public void UpdateStaminaBar()
    {
        if (staminaBar != null)
        {
            staminaBar.fillAmount = currentStamina / maxStamina;
        }
    }
    public void UpdateStaminaText()
    {
        if (staminatext != null)
        {
            staminatext.text = Mathf.RoundToInt(currentStamina) + " / " + Mathf.RoundToInt(maxStamina);
        }
    }

    public void SetRunning(bool running)
    {
        isRunning = running;
    }
}
