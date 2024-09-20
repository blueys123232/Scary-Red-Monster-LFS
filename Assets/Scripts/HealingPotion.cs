using UnityEngine;

public class HealingPotion : MonoBehaviour
{
    public int healAmount = 50; // Amount of health the potion restores

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player is colliding with the potion
        if (collision.gameObject.CompareTag("Player"))
        {
            // Access the player's health script and heal the player
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount); // Heal the player by the specified amount
            }

            // Destroy the potion after it's used
            Destroy(gameObject);
        }
    }
}
