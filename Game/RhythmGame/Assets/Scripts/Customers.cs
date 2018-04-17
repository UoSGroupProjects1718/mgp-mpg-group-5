using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customers : MonoBehaviour {

    static public Transform cust1Activator;
    static public Transform cust2Activator;

    public void PickRandomCustomer()
    {
        if (GameManager.instance.playerTurn == 1)
        {
            // Reset player two activator
            if (cust2Activator != null) { cust2Activator.gameObject.SetActive(false); }

            // Pick a random customer from the list
            GameObject randomCustomer = GameManager.instance.playerOneList[Random.Range(0, GameManager.instance.playerOneList.Count)];
            cust1Activator = randomCustomer.transform.GetChild(0);
            cust1Activator.gameObject.SetActive(true);
        }
        else if (GameManager.instance.playerTurn == 0)
        {
            // Reset player one activator
            if (cust1Activator != null) { cust1Activator.gameObject.SetActive(false); }

            // Pick a random customer from the list
            GameObject randomCustomer2 = GameManager.instance.playerTwoList[Random.Range(0, GameManager.instance.playerTwoList.Count)];
            cust2Activator = randomCustomer2.transform.GetChild(0);
            cust2Activator.gameObject.SetActive(true);
        }
    }
}
