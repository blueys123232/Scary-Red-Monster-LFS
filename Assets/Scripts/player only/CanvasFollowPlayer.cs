using UnityEngine;

public class CanvasFollowPlayer : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Vector3 offset = new Vector3(0f, 0f, 0f); // Offset from the player's position

    void LateUpdate()
    {
        if (player != null)
        {
            // Desired position is the player's position plus the offset
            Vector3 targetPosition = player.position + offset;

            // Directly set the position of the canvas to the target position
            transform.position = targetPosition;
        }
    }
}
