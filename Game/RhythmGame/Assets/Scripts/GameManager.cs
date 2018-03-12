using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    // Singleton pattern to make sure only one instance of GameManager exists
    public static GameManager instance = null;

    Node node;

    public SpawnNode playerOneSpawner;
    public SpawnNode playerTwoSpawner;

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
            Destroy(node);
            playerTwoSpawner.SpawnNewNode();
        }
        else if (!isPlayerOne)
        {
            isPlayerOne = true;
            Destroy(node);
        }
    }
}
