using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformmovement : MonoBehaviour
{    
    [SerializeField] GameObject[] waypoints;
    int currentWaypoint = 0;

    [SerializeField] float speed = 1f;
    void Update()
    {   
         //Current position (transform.position) touches waypoint, then move to the next one
        if (Vector3.Distance(transform.position, waypoints[currentWaypoint].transform.position) < 0.1f){
            currentWaypoint++;

            //Back to starting position
            if (currentWaypoint >= waypoints.Length){
                currentWaypoint = 0;
            }          
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, speed * Time.deltaTime);
    }
}

