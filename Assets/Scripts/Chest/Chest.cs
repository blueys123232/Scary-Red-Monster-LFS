using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject ChestClosed;
    public GameObject ChestOpen; // The object that will be revealed when the chest is opened

    private bool isOpened = false;
     void Start()
    {
        if (ChestClosed != null)
        {
            ChestClosed.SetActive(true);
        }
        if (ChestOpen != null)
        {
            ChestOpen.SetActive(false);
        }
    }
    
       
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PickUpmanager puManager = FindAnyObjectByType<PickUpmanager>();

            if (puManager != null && puManager.keyCount > 0 && !isOpened)
            {
                // Use the key to open the chest
                puManager.UseKey(); // This will remove the key and reduce the key count to 0
                OpenChest();
            }
            else
            {
                Debug.Log("Chest is locked. You need a key to open it.");
            }
        }
    }

    private void OpenChest()
    {
        if (!isOpened)
        {
            // Hide closed chest and show open chest 
            if (ChestClosed != null)
            {
                ChestClosed.SetActive(false); // Activate the hidden object
            }
            if (ChestOpen != null)
            {
                ChestOpen.SetActive(true); // Activate the hidden object
            }

            GetComponent<BoxCollider2D>().enabled = false;
            isOpened = true;
            Debug.Log("Chest opened.");
        }
    }
}