using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.InteropServices.WindowsRuntime;

public class PlayerStamina : MonoBehaviour
{
    public float currentStamina;
    [SerializeField] float maxStamina = 100f;
    [SerializeField] float staminaRegenRate = 5f;
    [SerializeField] float staminaDrainRate = 10f;
    public Image staminaBar;
    PlayerMovement PM;

    public TextMeshProUGUI staminatext;

    private bool isRunning = false;
    void Start()
    {
        PM = GetComponent<PlayerMovement>();
        currentStamina = maxStamina;
        UpdateStaminaBar();
        UpdateStaminaText();

    }

    void Update()
    {
        HandleStamina();
        Debug.Log(PM.isRunningPM);
    }

    void HandleStamina()
    {
        if (PM.isRunningPM == true && currentStamina > 0)
        {
            currentStamina -= staminaDrainRate * Time.deltaTime;
            if (currentStamina < 0)
            {
                currentStamina = 0;
                PM.isRunningPM = false;
            }
        }
        else if (!PM.isRunningPM && currentStamina < maxStamina)
        {
            currentStamina += staminaRegenRate * Time.deltaTime;
            if (currentStamina > maxStamina)
            {
                currentStamina = maxStamina;
            }
        }

        UpdateStaminaBar();
        UpdateStaminaText();
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

    public bool SetRunning(bool running)
    {
        isRunning = running;
        return running;
    }
}

