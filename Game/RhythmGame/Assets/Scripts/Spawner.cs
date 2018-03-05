using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

   // public GameObject[] spawners;
    public GameObject node;
    public Transform spawnLocation;

   // int arrayIndex;

    private void Start()
    {
        InvokeRepeating("SpawnNode", 0f, 3f);
    }

    // Randomly select a spawn point 
    public void SpawnNode()
    {
        Instantiate(node, spawnLocation.position, transform.rotation);
    }
}