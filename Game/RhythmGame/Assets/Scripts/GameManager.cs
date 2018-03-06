using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    // Singleton pattern to make sure only one instance of GameManager exists
    public static GameManager instance = null;

    Node node;

    private GameObject playerOneSpawner;
    private GameObject playerTwoSpawner;

    public bool isPlayerOne;

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
        isPlayerOne = false;

        //playerTwoSpawner.SetActive(false);
    }
    void Start ()
    {
        
    }

	void Update ()
    {
        
    }

    public void TurnSwitch(GameObject node)
    {
        print("Turn switch");

        if (isPlayerOne)
        {
            isPlayerOne = false;
            print("Player twos turn");
            Destroy(node);
        }
        else if (!isPlayerOne)
        {
            isPlayerOne = true;
            print("Player ones turn!");
            Destroy(node);
        }
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
