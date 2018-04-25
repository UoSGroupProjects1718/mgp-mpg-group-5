using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {

    // Singleton pattern to make sure only one instance of ScoreManager exists
    public static ScoreManager instance = null;

    //public static List<GameObject> playerOneCustomers;
    //public static List<GameObject> playerTwoCustomers;

    // Player score variables
    public int playerOneScore;
    public int playerTwoScore;

    public Animator p1WinText, p2WinText, p1WinChef, p2WinChef;

    private void Awake()
    {
        // Check if instance is equal to null
        if (instance == null)
        {
            // If no ScoreManager exists, set instance to this.
            instance = this;
        }
        else if (instance != this)
        {
            // If a ScoreManager already exists, destroy the new GameManager
            Destroy(gameObject);
        }
    }

    void Start ()
    {
        //GameObject p1Customers = GameObject.Find("Player One Customers");
    }

	void Update ()
    {
        if (GameManager.instance.playerOneList.Count == 10)
        {
            p1WinText.SetBool("p1Text", true);
            p1WinChef.SetBool("p1Chef", true);
        }
        if (GameManager.instance.playerTwoList.Count == 10)
        {
            p2WinText.SetBool("p2Text", true);
            p2WinChef.SetBool("p2Chef", true);
        }
    }

    public void UpdateCustomers()
    {
       
    }
}
