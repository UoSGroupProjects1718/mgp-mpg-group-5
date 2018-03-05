using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    // Singleton pattern to make sure only one instance of GameManager exists
    public static GameManager instance = null;

    Node node;

    public bool isPlayerOne;

   /* public Transform[] = new Transform[1];
    public int currentWaypoint = 0;
    Transform targetWaypoint;*/

    private void Awake()
    {
        // Check if instance is equal to null
        if (instance == null)
        {
            // If no GameManager exists, set instance to this.
            instance = this;
        }
        else if (instance != this)
        {
            // If a GameManager already exists, destroy the new GameManager
            Destroy(gameObject);
        }

        // Set the first players turn
        isPlayerOne = true;
    }
    void Start ()
    {
        /*waypoints[0] = GameObject.Find("p1Waypoint1").transform;
        waypoints[1] = GameObject.Find("p1Waypoint2").transform;*/
    }

	void Update ()
    {
        //node.transform.position = Vector2.MoveTowards(node.transform.position, waypoints[0].transform.position, node.speed * Time.deltaTime);
	}

    // Add the players score
    void AddScore(int score)
    {

    }

    // Select the next waypoint
    void SetWaypoint()
    {

    }

    // Move the node to the chosen waypoint
    void MoveNode()
    {

    }
}
