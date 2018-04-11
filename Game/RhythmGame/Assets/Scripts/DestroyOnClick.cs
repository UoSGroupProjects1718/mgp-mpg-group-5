using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnClick : MonoBehaviour {

    Activator activator;
    Customers customer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        activator = customer.cust1Activator

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject == gameObject)
                {
                    if (activator != null &&activator.GetStatus() == true )
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
