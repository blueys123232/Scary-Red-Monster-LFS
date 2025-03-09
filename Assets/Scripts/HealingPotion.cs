using UnityEngine;

public class HealingPotion : MonoBehaviour
{
    public Sprite HealingPotionSprite; // Amount of health the potion restores
    // Added so Each Potion Pick can be Worth a diffrent amount
    public int potionPickupAmount;
  
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Inventory playerInventoryUI = collision.GetComponentInChildren<Inventory>();
        PlayerInventory pInv = collision.GetComponent<PlayerInventory>();

        if (playerInventoryUI != null)
        {
            // Add the potion sprite to the currently selected inventory slot
            playerInventoryUI.AddItem(HealingPotionSprite);
            pInv.AddPotion();

            // Destroy the Potion game object after collection
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Player's inventory UI not found.");
        }
    }
}


