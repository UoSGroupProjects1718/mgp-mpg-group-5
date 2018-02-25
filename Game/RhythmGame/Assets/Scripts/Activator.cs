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
    void Update()
    {
        if (Input.GetKeyDown(key) && active)
        { 
            nodee.Dir = 2;
            CheckDistance();
      }
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

    void CheckDistance()
    {
        float differenceX = this.transform.position.x - nodee.transform.position.x;
        float differenceY = this.transform.position.y - nodee.transform.position.y;

        float totalDifference = differenceX + differenceY;

        Debug.Log(totalDifference);
    }
}
