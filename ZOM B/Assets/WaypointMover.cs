using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    [SerializeField] private Waypoints waypoints; //Stores ref to the waypoints.
    [SerializeField] private float movespeed = 5f;
    [SerializeField] private float distanceThreshold = 0.1f;

    private Transform currentWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        //Set inital pos to 1st Waypoint
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;


        // Set next Waypoint target
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
 

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, movespeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
        {
            currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        }
    }
}
