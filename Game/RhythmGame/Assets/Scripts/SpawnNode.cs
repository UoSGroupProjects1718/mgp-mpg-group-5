using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNode : MonoBehaviour {

    // Create a reference to a node
    public GameObject node;

    // Create a reference to the location of the spawner this script is attached to.
    public Transform spawnLocation;

	// Use this for initialization
	void Start ()
    {
        //InvokeRepeating("SpawnNewNode", 0f, 3f);
        
    }
	
	public void SpawnNewNode()
    {
        // Create a copy of node at the spawnLocation
        Instantiate(node, spawnLocation.position, transform.rotation);
    }
}
