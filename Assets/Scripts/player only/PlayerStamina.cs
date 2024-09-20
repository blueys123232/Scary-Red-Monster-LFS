using UnityEngine;
using UnityEngine.UI;

public class PlayerStamina : MonoBehaviour
{
    public float maxStamina = 100f;
    public float currentStamina;
    public float staminaRegenRate = 5f;
    public float staminaDrainRate = 10f;
    public Image staminaBar;

    private bool isRunning = false;

    void Start()
    {
        currentStamina = maxStamina;
        UpdateStaminaBar();
    }

    void Update()
    {
        HandleStamina();
        UpdateStaminaBar();
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

    public void SetRunning(bool running)
    {
        isRunning = running;
    }
}
