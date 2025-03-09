using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private int keyCount = 0; // Current number of keys the player has
    public int potCount = 0;
    Inventory inventoryUI;
    HealingPotion hPot;

    // Method to add a key to the player's inventory
    private void Start()
    {
        inventoryUI = GetComponent<Inventory>();
        hPot = FindAnyObjectByType<HealingPotion>();
    }
    public void AddKey()
    {
        keyCount++;
        Debug.Log("Key added. Total keys: " + keyCount);
    }

    // Method to get the current key count
    public int GetKeyCount()
    {
        return keyCount;
    }

    // Method to check if the player has at least one key
    public bool HasKey()
    {
        return keyCount > 0;
    }

    // Method to use a key, reducing the key count by 1
    public void UseKey()
    {
        if (keyCount > 0)
        {
            keyCount--;
            Debug.Log("Key used. Keys remaining: " + keyCount);
            if(keyCount <= 0)
            {
                inventoryUI.AddItem(inventoryUI.DefaultSlotSprite);
            }
        }
        else
        {
            Debug.Log("No keys left to use.");
        }
    }

    public void AddPotion()
    {
        // Add Number of Healing Potions Specified in the healing potion Script
        potCount += hPot.potionPickupAmount;
    }


public void UsePotion()
{
    if (potCount > 0)
    {
        potCount = potCount - 1;
            if(potCount <= 0)
            {
                inventoryUI.AddItem(inventoryUI.DefaultSlotSprite);
            }
    }
    else
       {
        Debug.Log("No more Potions anymore");
       }
    }
}