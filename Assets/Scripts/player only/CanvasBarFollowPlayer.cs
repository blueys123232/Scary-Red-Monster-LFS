using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasBarFollowPlayer : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Vector3 offset = new Vector3(0f, 2f, 0f); // Offset from the player's position

    void Update()
    {
        if (player != null)
        {
            // Update the canvas position to follow the player with the specified offset
            transform.position = player.position + offset;
        }
    }
}