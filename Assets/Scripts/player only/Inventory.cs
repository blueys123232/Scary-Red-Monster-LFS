using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    Empty,
    Full, 
}

public class Inventory : MonoBehaviour
{
    public Image[] slots; // Array to hold the inventory slots
    public ItemType[] itemType;
    public bool[] slotsEmpty;
    public int selectedSlotIndex = 0; // Tracks the currently selected slot index
    public Sprite DefaultSlotSprite;


    void Start()
    {
        // Initialize the inventory slots
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] != null)
            {
                slots[i].sprite = DefaultSlotSprite;
                slots[i].color = Color.gray; // Clear the slots initially
                itemType[i] = ItemType.Empty;
                slotsEmpty[i] = true;
            }
            else
            {
                Debug.LogWarning($"Slot {i + 1} not assigned in inspector.");
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
            selectedSlotIndex--;
            if (selectedSlotIndex < 0) selectedSlotIndex = slots.Length - 1;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            
            selectedSlotIndex++;
            if (selectedSlotIndex >= slots.Length) selectedSlotIndex = 0;
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
                slots[i].color = new Color(0.8f, 0.8f, 0.8f, 1f); // Highlighted
            else
                slots[i].color = slotsEmpty[i] ? Color.gray : Color.white;
        }
    }

    // Add item to the currently selected slot if empty
    public void AddItem(Sprite itemSprite, ItemType newItemType = ItemType.Full)
    {
        if (slotsEmpty[selectedSlotIndex] && slots[selectedSlotIndex] != null)
        {
            if (itemSprite != null)
            {
                slots[selectedSlotIndex].sprite = itemSprite;
                slots[selectedSlotIndex].color = Color.white; // Occupied
                slotsEmpty[selectedSlotIndex] = false;
                itemType[selectedSlotIndex] = newItemType;

                Debug.Log($"Item added to slot {selectedSlotIndex + 1}");
                ScrollToSlot(selectedSlotIndex);
            }
            else
            {
                Debug.LogWarning("Item sprite is null, cannot add.");
            }
        }
<<<<<<< HEAD
=======
    }

    // Method to add an item to the currently selected inventory slot
    public void AddItem(Sprite itemSprite)
    {
        if (slots[selectedSlotIndex] != null && slotsEmpty[selectedSlotIndex] == true)
        {
            if(itemSprite == null)
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
                Debug.Log("Inventory Slot occupied");
            }

        }
>>>>>>> 0e1d4cbcd3fb9157acae26a0ba8f3ee0f3f67ee3
        else
        {
            Debug.LogWarning("Selected slot is occupied or invalid.");
        }
    }

    // Add item to the first empty slot found
    public bool AddItemToFirstEmptySlot(Sprite itemSprite, ItemType newItemType = ItemType.Full)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slotsEmpty[i] && slots[i] != null)
            {
                slots[i].sprite = itemSprite;
                slots[i].color = Color.white;
                slotsEmpty[i] = false;
                itemType[i] = newItemType;

                Debug.Log($"Item added to first empty slot: {i + 1}");
                ScrollToSlot(i);
                HighlightSlot(i);
                return true;
            }
        }
        Debug.LogWarning("No empty slot available to add the item.");
        return false;
    }

    // Remove item from the currently selected slot
    public void RemoveItem()
    {
        if (!slotsEmpty[selectedSlotIndex] && slots[selectedSlotIndex] != null)
        {
            slots[selectedSlotIndex].sprite = DefaultSlotSprite;
            slots[selectedSlotIndex].color = Color.gray;
            slotsEmpty[selectedSlotIndex] = true;
            itemType[selectedSlotIndex] = ItemType.Empty;

            Debug.Log($"Item removed from slot {selectedSlotIndex + 1}");
        }
        else
        {
            Debug.LogWarning("No item to remove from this slot.");
        }
    }
    public bool FullSlot()
    { 
        for (int i = 0; i < slotsEmpty.Length; i++)
        {
            if (slotsEmpty[i]) return false;
        }
        return true;
    }
    void ScrollToSlot(int slotIndex)
    {
<<<<<<< HEAD
<<<<<<< HEAD
        // Optional: add UI scroll logic if needed
=======
        
>>>>>>> 0e1d4cbcd3fb9157acae26a0ba8f3ee0f3f67ee3
=======
        
>>>>>>> 0e1d4cbcd3fb9157acae26a0ba8f3ee0f3f67ee3
    }
}







































































































































































































































































































































































































































































































































