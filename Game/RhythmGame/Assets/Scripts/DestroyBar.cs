using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBar : MonoBehaviour {

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
