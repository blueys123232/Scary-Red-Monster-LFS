using UnityEngine;

public class Key : MonoBehaviour
{
    public Sprite keySprite; // The sprite representing the key
    public bool AlreadyAkey;

    Inventory playerInventoryUI;
    PlayerInventory pInv;

    private void Start()
    {
        playerInventoryUI = FindAnyObjectByType<Inventory>();
        pInv = FindAnyObjectByType<PlayerInventory>();

    }

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            if (playerInventoryUI != null && playerInventoryUI.slotsEmpty[playerInventoryUI.selectedSlotIndex] == true && !AlreadyAkey)
            {
                PickupKey();
            }
            else
            {
                Debug.Log("Player's inventory UI not found.");
            }
        }

        if (AlreadyAkey)
        {
            pInv.AddKey();
            Destroy(gameObject);
        }
    }

    void PickupKey()
    {
        AlreadyAkey = true;
        // Add the key sprite to the currently selected inventory slot
        playerInventoryUI.itemType[playerInventoryUI.selectedSlotIndex] = ItemType.Key;
        playerInventoryUI.AddItem(keySprite);
        pInv.AddKey();

        // Destroy the key game object after collection
        Destroy(gameObject);
    }

    
}