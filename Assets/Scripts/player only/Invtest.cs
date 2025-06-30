using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invtest : MonoBehaviour
{
    Inventory inventory;
    public Sprite _sprite;

    // Start is called before the first frame update
    void Start()
    {
        inventory = FindAnyObjectByType<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            inventory.AddItemToFirstEmptySlot(_sprite);
            //inventory.AddItem(_sprite);
<<<<<<< HEAD
            Destroy(this);
=======
            Destroy(this.gameObject);
>>>>>>> 08de1bc0fa1e482b247ea91216b788fbe3155b00
        }
    }
}