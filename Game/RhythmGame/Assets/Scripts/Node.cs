﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    Rigidbody2D rb;
    public float speed;
    public int Dir;

    public Transform[] p1Waypoints = new Transform[5];
    public int p1CurrentWaypoint = 0;

    public Transform[] p2Waypoints = new Transform[5];
    public int p2CurrentWaypoint = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Start () {        
        p1Waypoints[0] = GameObject.Find("p1Waypoint1").transform;
        p1Waypoints[1] = GameObject.Find("p1Waypoint2").transform;
        p1Waypoints[2] = GameObject.Find("p1Waypoint3").transform;

        p2Waypoints[0] = GameObject.Find("p2Waypoint1").transform;
        p2Waypoints[1] = GameObject.Find("p2Waypoint2").transform;
        p2Waypoints[2] = GameObject.Find("p2Waypoint3").transform;
    }

    void Update()
    {
        if (GameManager.instance.isPlayerOne && this.tag == "PlayerOneTag")
        {
            rb.transform.position = Vector2.MoveTowards(rb.transform.position, p1Waypoints[p1CurrentWaypoint].transform.position, speed * Time.deltaTime);

            if (Vector2.Distance(this.transform.position, p1Waypoints[p1CurrentWaypoint].transform.position) < 0.1)
            {
                p1CurrentWaypoint++;
                if (p1CurrentWaypoint >= 3)
                {
                    Destroy(this.gameObject);
                }
            }
            NodeClick();
        }
        else if (!GameManager.instance.isPlayerOne && this.tag == "PlayerTwoTag")
        {
            rb.transform.position = Vector2.MoveTowards(rb.transform.position, p2Waypoints[p2CurrentWaypoint].transform.position, speed * Time.deltaTime);

            if (Vector2.Distance(this.transform.position, p2Waypoints[p2CurrentWaypoint].transform.position) < 0.1)
            {
                p2CurrentWaypoint++;
                if (p2CurrentWaypoint >= 3)
                {
                    Destroy(this.gameObject);
                }
            }
            NodeClick();
        }        
    }

    void NodeClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Destroy(this.gameObject);
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
    }
}
