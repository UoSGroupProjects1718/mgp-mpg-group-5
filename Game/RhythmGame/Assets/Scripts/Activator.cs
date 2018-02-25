using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour {

    public KeyCode key;
    public bool active = false;
    GameObject node;

    public Node nodee;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(key) && active)
            nodee.Dir = 2;
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        active = true;
        if (collision.gameObject.tag == "Node")
        {
            node = collision.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        active = false;
    }
}
