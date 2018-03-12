using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNode : MonoBehaviour {

    public GameObject node;

    public Transform spawnLocation;

	// Use this for initialization
	void Start ()
    {
        //InvokeRepeating("SpawnNewNode", 0f, 3f);
        
    }
	
	// Update is called once per frame
	public void SpawnNewNode()
    {
        Instantiate(node, spawnLocation.position, transform.rotation);
    }
}
