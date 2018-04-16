using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour {

    //public KeyCode key;
    public bool active = false;
    GameObject nodeObj;

    // Script references
    Node node;

    void Awake ()
    {
    }

    // Update is called once per frame
    void Update()
    {
    
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        active = true;
        //if (collision.gameObject.tag == "Node")
        //{
        //    nodeObj = collision.gameObject;
        //    node = collision.gameObject.GetComponent<Node>();
        //}
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        active = false;
    }

    public bool GetStatus()
    {
        return active;
    }
}
