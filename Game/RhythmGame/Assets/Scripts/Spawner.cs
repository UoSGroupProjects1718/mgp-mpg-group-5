using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject playerOneNode;
    public GameObject playerTwoNode;

    public Transform playerOneSpawnLocation;
    public Transform playerTwoSpawnLocation;

    // int arrayIndex;

    private void Start()
    {
        InvokeRepeating("SpawnNode", 0f, 3f);
    }

    // Randomly select a spawn point 
    public void SpawnNode()
    {
        if(GameManager.instance.isPlayerOne)
            Instantiate(playerOneNode, playerOneSpawnLocation.position, transform.rotation);

        else if (!GameManager.instance.isPlayerOne)
            Instantiate(playerTwoNode, playerTwoSpawnLocation.position, transform.rotation);
    }
}