using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    Inventory inventory;

    public Sprite weaponSprite;
    
    public enum WeaponType
    {
        None,
        Pistol,
        Shotgun
    }

    // Start is called before the first frame update
    void Start()
    {
        inventory = FindAnyObjectByType<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (inventory != null) 
        
        {
            inventory.AddItem(weaponSprite);
            Destroy(gameObject);

        }
        else
        {
            Debug.LogError("Player inventory not found");
        }

        
    }
}
