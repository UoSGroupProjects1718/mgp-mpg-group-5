using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnClick : MonoBehaviour {

    bool activator;
    Activator activator2;
    Customers customer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //activator = customer.cust1Activator.GetComponent<Activator>().active;
        //activator2 = customer.cust2Activator.GetComponent<Activator>();

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject == gameObject)
                {
                    if (Customers.cust1Activator == true || Customers.cust2Activator == true)
                    {
                        GameManager.instance.isPlayerOne = !GameManager.instance.isPlayerOne;
                        Destroy(gameObject);

                        if (hit.collider.gameObject.tag == "PlayerOneTag")
                        {
                            // Code for player one score.
                        }

                        if (hit.collider.gameObject.tag == "PlayerOneTag")
                        {
                            // Code for player two score.
                        }
                    }
                }
            }
        }


	}
}
