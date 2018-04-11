using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour {

    public KeyCode key;
    public bool active = false;
    GameObject nodeObj;

    // Script references
    Node node;

   // Spawner spawn;

   // ScoreManager score;

    void Awake ()
    {
        //score = GameObject.Find("GameController").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.touchCount > 0)
        //{
           // Touch touch = Input.touches[0];

           /* if (Input.GetKeyDown(key) && active)
            {
            float totalDifference = Vector2.Distance(this.transform.position, nodeObj.transform.position);

                if (totalDifference >= 0.7f)
                {
                    node.Dir = 2;
                    ScoreManager.instance.AddScore("Bad");
                    print("Bad " + totalDifference);
                }
                else if (totalDifference >= 0.3f)
                {
                    print("Good " + totalDifference);
                    node.Dir = 2;
                    ScoreManager.instance.AddScore("Good");
                }
                else if (totalDifference <= 0.2f)
                {
                    print("Perfect " + totalDifference);
                    node.Dir = 2;
                    ScoreManager.instance.AddScore("Perfect");
                }

                // Destroy(nodeObj);
            }*/
       // }
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

    public bool GetStatus()
    {
        return active;
    }

    void CheckDistance()
    {
        

        //Debug.Log(totalDifference);
    }
}
