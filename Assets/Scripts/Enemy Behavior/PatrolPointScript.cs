using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPointScript : MonoBehaviour
{
    //List of all the points that the entity this script is on will move towards
    [SerializeField] List<Transform> points = new List<Transform>();
    // the point that becomes the one it move to after its gotten to the last one
    private Transform target;


    //Numbers othe waypoints and also specify the minimum distance the entity needs to be before it has got to its destination
    private int targetWaypointNumber = 0;
    private float miniumDistance = 0.1f;
    private int lastWaypointNumber;
    // the movement of a player
    [SerializeField] private float moveSpeed = 3.0f;


    // Start is called before the first frame
    void Start()
    {
        lastWaypointNumber = points.Count - 1;
        target = points[targetWaypointNumber];
    }

    // Update is called once per frame
    void Update()
    {
        //how fast we are moving each point
        float moveStep = moveSpeed * Time.deltaTime;

        //Distance betwwn the entity and whatever the current tart is
        float distance = Vector2.Distance(transform.position, target.position);
        CheckDistance(distance);
    }
    void CheckDistance(float curentDistance)
    {
        if (curentDistance < miniumDistance)
        {
            targetWaypointNumber++;
            ChangeTarget();
        }
    }

    void ChangeTarget()
    {
        if(targetWaypointNumber > lastWaypointNumber)
        {
            targetWaypointNumber = 0;
        }
        target = points[targetWaypointNumber];
    }

}