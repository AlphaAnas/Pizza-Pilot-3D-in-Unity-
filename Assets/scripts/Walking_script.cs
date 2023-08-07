using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    //we didnt need start this time so deleted it
    //instead of declaring the 2 waypoints,we will declare an entire array of them so that our objects can move betwee nas many of them as needed, its type is  gameobject cuz the waypoints are empty gameobjetcs
    [SerializeField] GameObject[] waypoints;
    int currentWaypointIndex = 0;

    [SerializeField] float speed = 1f; //speed of moving between waypoints
    void Update()
    {   //how to switch between waypoints
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < 0.1f) // here we checking dist bw platform and current active waypoint ,if dist less than 0.1f means we touched that current active waypoint, better than writing 0
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;//to switch back to the first waypoint if we are on the last one
            }
        }


        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);    //for changing the position of the platform, movetowards is a method that calculates the distance between two game objetcct, transform.position gives current platform position
    }
}
//probelm= while standing on the moving platform, the player was not moving along with it
//solutiom= as soon as player comes on that platform,just make the player the child of the floor it is standing on (cuz camera is child of player so moves along with it, so similarly)