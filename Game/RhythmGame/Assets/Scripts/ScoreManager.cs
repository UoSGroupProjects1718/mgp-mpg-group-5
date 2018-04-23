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
        if (playerOneScore > playerTwoScore + 50 || playerOneScore > 50)
        {
            SceneManager.LoadScene(3);
        }
        if (playerTwoScore > playerOneScore + 50 || playerTwoScore > 50)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void UpdateCustomers()
    {
       
    }
}
