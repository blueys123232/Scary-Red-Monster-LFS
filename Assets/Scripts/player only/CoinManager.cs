using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public TextMeshProUGUI coinText; // Reference to the TextMeshProUGUI component
    private int coinCount = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateCoinText();
    }

    public void AddCoin()
    {
        coinCount++;
        UpdateCoinText();
    }

    void UpdateCoinText()
    {
        coinText.text = "Coins: " + coinCount.ToString();
    }
}
