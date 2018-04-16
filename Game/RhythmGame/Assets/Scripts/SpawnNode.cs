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
        
    }
	
	public GameObject SpawnNewNode()
    {
        // Create a copy of node at the spawnLocation
        return Instantiate(node, new Vector3(spawnLocation.position.x, spawnLocation.position.y, spawnLocation.position.z + 0.01f), transform.rotation);
    }
}
