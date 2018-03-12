using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chef : MonoBehaviour {


    Transform[] p1chefWaypoints = new Transform[5];
    Transform[] p2chefWaypoints = new Transform[5];
    public int chefCurrentWaypoint = 0;
    public int chef2CurrentWaypoint = 0;

    Rigidbody2D rb;

    public float speed = 3;
    public float timer;

    void Awake ()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = Random.Range(0, 3);
    }

    private void Start()
    {
        p1chefWaypoints[0] = GameObject.Find("p1ChefWaypoint1").transform;
        p1chefWaypoints[1] = GameObject.Find("p1ChefWaypoint2").transform;
        p1chefWaypoints[2] = GameObject.Find("p1ChefWaypoint3").transform;
        p1chefWaypoints[3] = GameObject.Find("p1ChefWaypoint4").transform;
        p1chefWaypoints[4] = GameObject.Find("p1ChefWaypoint5").transform;

        p2chefWaypoints[0] = GameObject.Find("p2ChefWaypoint1").transform;
        p2chefWaypoints[1] = GameObject.Find("p2ChefWaypoint2").transform;
        p2chefWaypoints[2] = GameObject.Find("p2ChefWaypoint3").transform;
        p2chefWaypoints[3] = GameObject.Find("p2ChefWaypoint4").transform;
        p2chefWaypoints[4] = GameObject.Find("p2ChefWaypoint5").transform;
    }

    // Update is called once per frame
    void Update ()
    {
        timer -= Time.deltaTime;

        if (this.gameObject.tag == "PlayerOneTag")
        {
            rb.transform.position = Vector2.MoveTowards(rb.transform.position, p1chefWaypoints[chefCurrentWaypoint].transform.position, speed * Time.deltaTime);

            if (timer <= 0f)
            {
                timer = Random.Range(0, 3);
                chefCurrentWaypoint = Random.Range(0, 5);
            }
        }

        if (this.gameObject.tag == "PlayerTwoTag")
        {
            rb.transform.position = Vector2.MoveTowards(rb.transform.position, p2chefWaypoints[chef2CurrentWaypoint].transform.position, speed * Time.deltaTime);

            if (timer <= 0f)
            {
                timer = Random.Range(0, 3);
                chef2CurrentWaypoint = Random.Range(0, 5);
            }
        }
    }
}
