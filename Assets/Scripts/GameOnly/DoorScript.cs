using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    private HashSet<GameObject> DoorObjects = new HashSet<GameObject>();

    [SerializeField] private Transform destination;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            return;
        }
        if (DoorObjects.Contains(collision.gameObject))
        {
            return;
        }

        if (destination.TryGetComponent(out DoorScript destinationDoor))
        {
            destinationDoor.DoorObjects.Add(collision.gameObject);
        }

        collision.transform.position = destination.position;
    }




    private void OnTriggerExit2D(Collider2D collision)
    {
        {
            return;
        }

        DoorObjects.Remove(collision.gameObject);
    }
}
