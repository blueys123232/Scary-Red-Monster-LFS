using UnityEngine;

public class Key : MonoBehaviour
{
    public Sprite keySprite; // The sprite representing the key

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory playerInventoryUI = other.GetComponentInChildren<Inventory>();
            PlayerInventory pInv = other.GetComponent<PlayerInventory>();

            if (playerInventoryUI != null)
            {
                // Add the key sprite to the currently selected inventory slot
                playerInventoryUI.AddItem(keySprite);
                Debug.Log("Key added to inventory UI.");
                pInv.AddKey();
                // Destroy the key game object after collection
                Destroy(gameObject);
                Debug.Log("Key collected and destroyed.");
            }
            else
            {
                Debug.Log("Player's inventory UI not found.");
            }
        }
    }
}