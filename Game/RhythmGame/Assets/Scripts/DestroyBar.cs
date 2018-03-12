using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBar : MonoBehaviour {

    /* SCRIPT IS NO LONGER USED SINCE NODES FOLLOW WAYPOINTS
     * 
     * PURELY HERE FOR REFERENCE TO OLD METHOD
     * 
     * SCHEDULED FOR DELETION
     * 
     */


    GameObject toDestroy;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Node")
        {
            toDestroy = collision.gameObject;
            Destroy(toDestroy);
        }
       
    }
}
