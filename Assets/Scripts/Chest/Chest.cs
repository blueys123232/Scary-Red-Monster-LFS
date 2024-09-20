using UnityEngine;

public class Chest : MonoBehaviour
{
    public Sprite openChestSprite; // The sprite representing the open chest
    public GameObject itemInside; // The object that will be revealed when the chest is opened

    private bool isOpened = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

            if (playerInventory != null && playerInventory.HasKey() && !isOpened)
            {
                // Use the key to open the chest
                playerInventory.UseKey(); // This will remove the key and reduce the key count to 0
                OpenChest();
            }
            else if (!playerInventory.HasKey())
            {
                Debug.Log("Chest is locked. You need a key to open it.");
            }
        }
    }

    private void OpenChest()
    {
        if (!isOpened)
        {
            // Change the chest's sprite to the open chest sprite
            GetComponent<SpriteRenderer>().sprite = openChestSprite;

            // Reveal the item inside the chest
            if (itemInside != null)
            {
                itemInside.SetActive(true); // Activate the hidden object
            }

            isOpened = true;
            Debug.Log("Chest opened.");
        }
    }
}
