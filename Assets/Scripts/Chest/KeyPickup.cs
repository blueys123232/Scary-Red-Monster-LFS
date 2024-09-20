using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public Sprite keySprite; // Assign the key's sprite in the Inspector

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Inventory playerInventory = collision.GetComponent<Inventory>();
            if (playerInventory != null)
            {
                playerInventory.AddItem(keySprite); // Add the key to the player's inventory
                Destroy(gameObject); // Remove the key from the scene
            }
        }
    }
}
