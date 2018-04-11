using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customers : MonoBehaviour {

    public Transform cust1Activator;
    public Transform cust2Activator;

    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    public void PickRandomCustomer()
    {
        if (GameManager.instance.isPlayerOne)
        {
            //print("Yooooo");
            // Reset player two activator
            if (cust2Activator == null)
            {
                print("returning");
            }
            else
            {
                print("resetting");
                cust2Activator.gameObject.SetActive(false);
            }

            // Pick a random customer from the list
            GameObject randomCustomer = GameManager.instance.playerOneList[Random.Range(0, GameManager.instance.playerOneList.Count)];
            cust1Activator = randomCustomer.transform.GetChild(0);
            cust1Activator.gameObject.SetActive(true);

            // Just testing if this works!!!!!
            // randomCustomer.transform.localScale = new Vector3(4, 4, 4);
        }
        else
        {
            // Reset player one activator
            if (cust1Activator == null)
                return;
            else
                cust1Activator.gameObject.SetActive(false);

            // Pick a random customer from the list
            GameObject randomCustomer = GameManager.instance.playerTwoList[Random.Range(0, GameManager.instance.playerTwoList.Count)];
            cust2Activator = randomCustomer.transform.GetChild(0);
            cust2Activator.gameObject.SetActive(true);



            //randomCustomer.transform.localScale = new Vector3(4, 4, 4);
        }
    }
}
