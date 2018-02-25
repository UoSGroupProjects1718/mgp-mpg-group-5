using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour {

    public KeyCode key;
    public bool active = false;
    GameObject nodeObj;
    Node node;

    //public Node node;

	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key) && active)
        {
            float totalDifference = Vector3.Distance(this.transform.position, nodeObj.transform.position);

            if (totalDifference >= 1)
            {
                Debug.Log(totalDifference + " BAD");
                node.Dir = 2;
            }
            else if (totalDifference >= 0.3)
            {
                Debug.Log(totalDifference + " GOOD");
                node.Dir = 2;
            }
            else if (totalDifference <= 0.3)
            { 
                Debug.Log(totalDifference + " PERFECT");
                node.Dir = 2;
            }

           // Destroy(nodeObj);
      }
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        active = true;
        if (collision.gameObject.tag == "Node")
        {
            nodeObj = collision.gameObject;
            node = collision.gameObject.GetComponent<Node>();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        active = false;
    }

    void CheckDistance()
    {
        

        //Debug.Log(totalDifference);
    }
}
