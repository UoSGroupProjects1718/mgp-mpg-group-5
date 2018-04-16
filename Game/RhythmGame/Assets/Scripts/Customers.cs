using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customers : MonoBehaviour {

    [SerializeField] static public Transform cust1Activator;
    [SerializeField] static public Transform cust2Activator;

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
        if (GameManager.instance.playerTurn == 1)
        {
            // Reset player two activator
            if (cust2Activator == null)
            {
               // print("returning");
            }
            else
            {
                //print("resetting");
                print(cust2Activator.name);
                cust2Activator.gameObject.SetActive(false);
            }

            // Pick a random customer from the list
            GameObject randomCustomer = GameManager.instance.playerOneList[Random.Range(0, GameManager.instance.playerOneList.Count)];
            cust1Activator = randomCustomer.transform.GetChild(0);
            cust1Activator.gameObject.SetActive(true);
        }
        else if (GameManager.instance.playerTurn == 0)
        {
            // Reset player one activator
            if (cust1Activator == null)
                return;
            else
            {
                print(cust1Activator.name);
                cust1Activator.gameObject.SetActive(false);
            }

            // Pick a random customer from the list
            GameObject randomCustomer2 = GameManager.instance.playerTwoList[Random.Range(0, GameManager.instance.playerTwoList.Count)];
            cust2Activator = randomCustomer2.transform.GetChild(0);
            cust2Activator.gameObject.SetActive(true);
        }
    }
}
