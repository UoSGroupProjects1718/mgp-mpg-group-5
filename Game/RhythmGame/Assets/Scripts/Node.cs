﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    // Reference to RigidBody2D
    Rigidbody2D rb;

    // Create a speed variable
    public float speed = 4f;

    #region Waypoint Variables

    // Create an array to store node waypoints
    Transform[] p1Waypoints = new Transform[5];
    Transform[] p2Waypoints = new Transform[5];

    // Variable to store the current waypoint array index
    int p1CurrentWaypoint = 0;
    int p2CurrentWaypoint = 0;

    // Variable to hold last waypoint index
    int finalWaypoint = 3;

    #endregion
    

    private void Awake()
    {
        // Assign RigidBody
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Start ()
    {        
        // Find player 1 waypoints and add them to the array
        p1Waypoints[0] = GameObject.Find("p1Waypoint1").transform;
        p1Waypoints[1] = GameObject.Find("p1Waypoint2").transform;
        p1Waypoints[2] = GameObject.Find("p1Waypoint3").transform;

        // Find player 2 waypoints and add them to the array
        p2Waypoints[0] = GameObject.Find("p2Waypoint1").transform;
        p2Waypoints[1] = GameObject.Find("p2Waypoint2").transform;
        p2Waypoints[2] = GameObject.Find("p2Waypoint3").transform;
    }

    void Update()
    {
        // Check if current player 1
        if (GameManager.instance.isPlayerOne && this.tag == "PlayerOneTag")
        {
            // Move the node towards the currently active waypoint
            rb.transform.position = Vector2.MoveTowards(rb.transform.position, p1Waypoints[p1CurrentWaypoint].transform.position, speed * Time.deltaTime);

            // Check if the node has hit the current target waypoint
            if (Vector2.Distance(this.transform.position, p1Waypoints[p1CurrentWaypoint].transform.position) < 0.1)
            {
                // Increment waypoint index to locate next point
                p1CurrentWaypoint++;

                // Check if the node has passed the final waypoint
                if (p1CurrentWaypoint >= finalWaypoint)
                {
                    Destroy(this.gameObject);
                }
            }
        }
        // Check if currently player 2
        else if (!GameManager.instance.isPlayerOne && this.tag == "PlayerTwoTag")
        {
            // Move the node towards the currently active waypoint
            rb.transform.position = Vector2.MoveTowards(rb.transform.position, p2Waypoints[p2CurrentWaypoint].transform.position, speed * Time.deltaTime);

            // Check if the node has hit the current target waypoint
            if (Vector2.Distance(this.transform.position, p2Waypoints[p2CurrentWaypoint].transform.position) < 0.1)
            {
                // Increment waypoint index to locate next point
                p2CurrentWaypoint++;

                // Check if the node has passed the final waypoint
                if (p2CurrentWaypoint >= finalWaypoint)
                {
                    Destroy(this.gameObject);
                }
            }
        }        
    }

   /* void NodeClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.instance.TurnSwitch(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        print("Touched activator");
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (collision.gameObject.tag == "Activator")
            {
                print("Touched Activator");
                Destroy(this.gameObject);
            }
            print("No activator detected");
        }
    }*/
}
