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

    Spawner spawn;

    ScoreManager score;

    int badScore = 10;
    int goodScore = 50;
    int perfectScore = 100;

    void Start () {
        score = GameObject.Find("Managers").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];

            if (Input.GetKeyDown(key) && active || touch.phase == TouchPhase.Began && active)
            {
                float totalDifference = Vector3.Distance(this.transform.position, nodeObj.transform.position);

                if (totalDifference >= 1)
                {
                    Debug.Log(totalDifference + " BAD");
                    node.Dir = 2;
                    score.playerOneScore += badScore;
                    print(score.playerOneScore);
                    score.UpdateString("Bad");
                }
                else if (totalDifference >= 0.3)
                {
                    Debug.Log(totalDifference + " GOOD");
                    node.Dir = 2;
                    score.playerOneScore += goodScore;
                    print(score.playerOneScore);
                    score.UpdateString("Good");
                }
                else if (totalDifference <= 0.3)
                {
                    Debug.Log(totalDifference + " PERFECT");
                    node.Dir = 2;
                    score.playerOneScore += perfectScore;
                    print(score.playerOneScore);
                    score.UpdateString("Perfect");
                }

                // Destroy(nodeObj);
            }
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
