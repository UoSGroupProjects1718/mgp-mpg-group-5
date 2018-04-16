using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnClick : MonoBehaviour {

    Customers customer;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	//void Update ()
 //   {
 //       if (Input.GetMouseButtonDown(0))
 //       {
 //           RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

 //           if (hit.collider)
 //           {
 //               if(hit.collider.tag == "PlayerOneTag" || hit.collider.tag == "PlayerTwoTag")
 //               {
 //                   if (hit.collider.gameObject == gameObject)
 //                   {
 //                       if (Customers.cust1Activator.GetComponent<Activator>().active == true || Customers.cust2Activator.GetComponent<Activator>().active == true)
 //                       {
 //                           GameManager.instance.isPlayerOne = !GameManager.instance.isPlayerOne;
 //                           Destroy(gameObject);

 //                           if (hit.collider.gameObject.tag == "PlayerOneTag")
 //                           {
 //                               ScoreManager.instance.playerOneScore += 10;
 //                           }

 //                           if (hit.collider.gameObject.tag == "PlayerTwoTag")
 //                           {
 //                               ScoreManager.instance.playerTwoScore += 10;
 //                           }
 //                       }
 //                   }
 //               }
 //           }
 //           else
 //           {
 //               print("What the hell is happening");
 //               if (GameManager.instance.isPlayerOne)
 //               {
 //                   Debug.Log("WTF");
 //                   GameManager.instance.TurnSwitch();
 //                   GameManager.instance.isPlayerOne = false;
 //               }
 //               else
 //               {
 //                   Debug.Log("WTFx2");
 //                   GameManager.instance.TurnSwitch();
 //                   GameManager.instance.isPlayerOne = true;
 //               }
 //           }
 //       }
	//}
}
