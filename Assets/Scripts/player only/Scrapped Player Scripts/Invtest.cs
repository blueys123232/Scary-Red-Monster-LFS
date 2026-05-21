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

            Destroy(this.gameObject);

        }
    }
}