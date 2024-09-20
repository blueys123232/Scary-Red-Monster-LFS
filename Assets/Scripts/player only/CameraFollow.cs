using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target the camera should follow (player)
    public Vector3 offset = new Vector3(-0.5f, 0f, -10f); // Offset between the camera and the target

    void Start()
    {
        // If offset is not manually set, calculate the initial offset
        if (offset == Vector3.zero)
        {
            offset = new Vector3(-0.5f, 0f, -10f); // Example closer offset
        }
    }

    void LateUpdate()
    {
        if (target != null)
        {
            // Directly set the camera's position to the target position plus offset
            transform.position = target.position + offset;
        }
    }
}