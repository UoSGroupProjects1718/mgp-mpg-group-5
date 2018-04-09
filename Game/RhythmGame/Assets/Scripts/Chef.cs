using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chef : MonoBehaviour
{
    // Create an array to store wander waypoints
    Transform[] p1chefWaypoints = new Transform[5];
    Transform[] p2chefWaypoints = new Transform[5];

    // Variable to store current array index
    public int chefCurrentWaypoint = 0;
    public int chef2CurrentWaypoint = 0;
    Vector3 lastPos;
    // Reference to GameObject RigidBody
    Rigidbody2D rb;

    // Control the speed the chefs move at
    public float speed = 3;

    // Timer to randomise when the chef will change target node
    public float timer;

    void Awake ()
    {
        // Assign RigidBody
        rb = GetComponent<Rigidbody2D>();
        // Randomise the timer variable
        timer = Random.Range(0, 3);
    }

    private void Start()
    {
        lastPos = this.transform.position;

        // Find all the chef waypoints for player 1 chef and add them to the corect array
        p1chefWaypoints[0] = GameObject.Find("p1ChefWaypoint1").transform;
        p1chefWaypoints[1] = GameObject.Find("p1ChefWaypoint2").transform;
        p1chefWaypoints[2] = GameObject.Find("p1ChefWaypoint3").transform;
        p1chefWaypoints[3] = GameObject.Find("p1ChefWaypoint4").transform;
        p1chefWaypoints[4] = GameObject.Find("p1ChefWaypoint5").transform;

        // Find all the chef waypoints for player 1 chef and add them to the corect array
        p2chefWaypoints[0] = GameObject.Find("p2ChefWaypoint1").transform;
        p2chefWaypoints[1] = GameObject.Find("p2ChefWaypoint2").transform;
        p2chefWaypoints[2] = GameObject.Find("p2ChefWaypoint3").transform;
        p2chefWaypoints[3] = GameObject.Find("p2ChefWaypoint4").transform;
        p2chefWaypoints[4] = GameObject.Find("p2ChefWaypoint5").transform;
    }

    // Update is called once per frame
    void Update ()
    {
        // Decrease the time smoothly using deltaTime
        timer -= Time.deltaTime;

        // Check if player 1 chef
        if (this.gameObject.tag == "PlayerOneTag")
        {
            // Move chef to current target waypoint
            rb.transform.position = Vector2.MoveTowards(rb.transform.position, p1chefWaypoints[chefCurrentWaypoint].transform.position, speed * Time.deltaTime);
            Quaternion.LookRotation(p1chefWaypoints[chefCurrentWaypoint].transform.position);

            // Check if the timer has run out
            if (timer <= 0f)
            {
                // Reset the timer to a random value between 0 and 3 (Max is exclusive)
                timer = Random.Range(0, 4);
                // Randomly select the next target waypoint to move towards
                chefCurrentWaypoint = Random.Range(0, 5);
            }
        }

        // Check if player 2 chef
        if (this.gameObject.tag == "PlayerTwoTag")
        {
            // Move chef to current target waypoint
            rb.transform.position = Vector2.MoveTowards(rb.transform.position, p2chefWaypoints[chef2CurrentWaypoint].transform.position, speed * Time.deltaTime);

            Vector3 reletivePosition = p2chefWaypoints[chef2CurrentWaypoint].transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(reletivePosition);
            transform.rotation.Set(rotation.x, rotation.y, rotation.z, rotation.w);

            // Check if the timer has run out
            if (timer <= 0f)
            {
                // Reset the timer to a random value between 0 and 3 (Max is exclusive)
                timer = Random.Range(0, 4);
                // Randomly select the next target waypoint to move towards
                chef2CurrentWaypoint = Random.Range(0, 5);
            }
        }

        //LookAtRotation();
    }

    void LookAtRotation()
    {
        Vector3 lastRotation = this.transform.eulerAngles;

        float targetRotation = Mathf.Atan2(lastPos.x, lastPos.y) * Mathf.Rad2Deg - 90;

        float newRotation = Mathf.LerpAngle(lastRotation.z, targetRotation, 6f);

        this.transform.rotation = Quaternion.AngleAxis(newRotation, Vector3.forward);



        /*
        if(lastPos == this.transform.position) { return; }

        Vector3 thisRot = this.transform.eulerAngles;

        this.transform.LookAt(lastPos);

        Vector3 newRot = this.transform.eulerAngles;

        this.transform.eulerAngles = new Vector3(thisRot.x, thisRot.y, newRot.z + 180);*/

        lastPos = this.transform.position;
    }
}
