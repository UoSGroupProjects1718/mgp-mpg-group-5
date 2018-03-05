using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    Rigidbody2D rb;
    public float speed;
    public int Dir;

    public bool spawned = false;

    public Transform[] waypoints = new Transform[5];
    public int currentWaypoint = 0;
    Transform targetWaypoint;

    private Transform target;

    //Transform targetWaypoint;

    //public bool playerOneTurn = true;

    //public int scoreValue = 100;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Dir = 1;
    }
    
    void Start () {
        // rb.velocity = new Vector2(-speed, 0);

        
        waypoints[0] = GameObject.Find("p1Waypoint1").transform;
        waypoints[1] = GameObject.Find("p1Waypoint2").transform;
        waypoints[2] = GameObject.Find("p1Waypoint3").transform;



        //target = waypoints[0];
    }
	
	void Update () {
        // SetDirection();


        rb.transform.position = Vector2.MoveTowards(rb.transform.position, waypoints[currentWaypoint].transform.position, speed * Time.deltaTime);

        if (Vector2.Distance(this.transform.position, waypoints[currentWaypoint].transform.position) < 0.1)
        {
            currentWaypoint++;
            if (currentWaypoint >= 3)
            {
                Destroy(this.gameObject);
            }
        }


        /*if (waypoints.Length == waypoints.Length + 1)
        {
            Destroy(this.gameObject);
        }*/
    }

    void GetNextWaypoint()
    {
        
    }

    /*void MoveTowards()
    {
        if (GameManager.instance.isPlayerOne)
        {
            for (int i = 0; i < moveTowards.Length; i++)
            {
                rb.transform.position = Vector2.MoveTowards(rb.transform.position, moveTowards[i].transform.position, speed * Time.deltaTime);

                if (Vector2.Equals(rb.transform.position, moveTowards[i].transform.position))
                    i++;
            }
        }
    }

    void SetDirection()
    {
        if (GameManager.instance.isPlayerOne)
        {
            if (Dir == 1)
            {
                rb.velocity = new Vector2(-speed, 0);
            }
            else if (Dir == 2)
            {
                rb.velocity = new Vector2(0, -speed);
            }
        }
        else if (!GameManager.instance.isPlayerOne)
        {
            if (Dir == 1)
            {
                rb.velocity = new Vector2(speed, 0);
            }
            else if (Dir == 2)
            {
                rb.velocity = new Vector2(0, -speed);
            }
        }
    }*/
}
