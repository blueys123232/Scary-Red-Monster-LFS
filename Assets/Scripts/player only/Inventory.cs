using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    Empty,
    Key,
    HealingPotion,
}

public class Inventory : MonoBehaviour
{
    public Image[] slots; // Array to hold the inventory slots
    public ItemType[] itemType;
    public bool[] slotsEmpty;
    public int selectedSlotIndex = 0; // Tracks the currently selected slot index
    //public bool slotOccupied;

    public Sprite DefaultSlotSprite;
    

    void Start()
    {
        // Initialize the inventory slots
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] != null)
            {
                slots[i].color = Color.clear; // Clear the slots initially
                itemType[i] = global::ItemType.Empty;
                slotsEmpty[i] = true;
            }
            else
            {
                Debug.Log("Slot " + (i + 1) + " is not assigned in the inspector.");
            }
        }

        // Highlight the initial slot
        HighlightSlot(selectedSlotIndex);
    }

    void Update()
    {
        HandleSlotSelection();
        HandleScrollWheel();
    }

    // Method to handle slot selection using number keys
    void HandleSlotSelection()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { SelectSlot(0); }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) { SelectSlot(1); }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) { SelectSlot(2); }
        else if (Input.GetKeyDown(KeyCode.Alpha4)) { SelectSlot(3); }
        else if (Input.GetKeyDown(KeyCode.Alpha5)) { SelectSlot(4); }
    }

    // Method to handle scroll wheel input
    void HandleScrollWheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            // Scroll up
            selectedSlotIndex--;
            if (selectedSlotIndex < 0)
            {
                selectedSlotIndex = slots.Length - 1;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            // Scroll down
            selectedSlotIndex++;
            if (selectedSlotIndex >= slots.Length)
            {
                selectedSlotIndex = 0;
            }
        }

        // Ensure the selected slot is within the visible range
        ScrollToSlot(selectedSlotIndex);
        HighlightSlot(selectedSlotIndex);
    }

    // Method to select and highlight a specific slot
    void SelectSlot(int slotIndex)
    {
        selectedSlotIndex = slotIndex;
        HighlightSlot(selectedSlotIndex);
    }

    // Method to highlight the currently selected slot
    void HighlightSlot(int slotIndex)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i == slotIndex)
            {
                slots[i].color = new Color(0.8f, 0.8f, 0.8f, 1f); // Highlight the selected slot with a light grey color
            }
            else
            {
                slots[i].color = slots[i].sprite != null ? Color.white : Color.clear; // Set color based on whether the slot is occupied
            }
        }
    }

    // Method to add an item to the currently selected inventory slot
    public void AddItem(Sprite itemSprite)
    {
        if (slots[selectedSlotIndex] != null && slotsEmpty[selectedSlotIndex] == true)
        {
            slots[selectedSlotIndex].sprite = itemSprite;
            slots[selectedSlotIndex].color = Color.white; // Set the slot to visible with the item image
            slotsEmpty[selectedSlotIndex] = false;
            Debug.Log("Item added to " + slots[selectedSlotIndex].name);
            //slotOccupied = true;
            Debug.Log("Sprite is " + slots[selectedSlotIndex].sprite);

            // Automatically scroll to the slot
            ScrollToSlot(selectedSlotIndex);
        }
        else
        {
            Debug.Log("Selected slot is null or already occupied");
        }

       
    }

    public void RemoveItem()
    
    {
        if (slots[selectedSlotIndex] != null && slots[selectedSlotIndex].sprite != DefaultSlotSprite && slotsEmpty[selectedSlotIndex] == false)
        {
            slots[selectedSlotIndex].sprite = DefaultSlotSprite;
            slots[selectedSlotIndex].color = Color.white;
            slotsEmpty[selectedSlotIndex] = true;
            Debug.Log("Item Removed From   " + slots[selectedSlotIndex].name);

        }
        else
        {
            Debug.Log("No item Cannot be Removed from the slot");
        }


}

    // Method to scroll to a specific slot
    void ScrollToSlot(int slotIndex)
    {
        Debug.Log("Scroll to Slot");
    }
}
