using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour {

    // Singleton pattern to make sure only one instance of ScoreManager exists
    public static ScoreManager instance = null;

    // Player score variables
    public int playerOneScore;
    public int playerTwoScore;

    // Reference to text component
    public Text textPlayerOne;
    public Text textPlayerTwo;

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

        // Reset player score on awake
        playerOneScore = 0;
        playerTwoScore = 0;
    }

    void Start ()
    {
        // Display players score on screen
        textPlayerOne.text = "Player one score " + playerOneScore.ToString();
        textPlayerTwo.text = "Player two score " + playerTwoScore.ToString();
    }

	void Update ()
    {
        // Display players score on screen
        textPlayerOne.text = "Player one score " + playerOneScore.ToString();
        textPlayerTwo.text = "Player two score " + playerTwoScore.ToString();
    }

    public void AddScore(string scoreType)
    {
        // Check if player 1
        if (GameManager.instance.isPlayerOne)
        {
            // Check scoreType, add correct score in relation to players performance
            if (scoreType == "Bad")
            {
                playerOneScore += 10;
            }
            else if (scoreType == "Good")
            {
                playerOneScore += 50;
            }
            else if (scoreType == "Perfect")
            {
                playerOneScore += 100;
            }
        }
        // Check if player 2
        else if (!GameManager.instance.isPlayerOne)
        {
            // Check scoreType, add correct score in relation to players performance
            if (scoreType == "Bad")
            {
                playerTwoScore += 10;
            }
            else if (scoreType == "Good")
            {
                playerTwoScore += 50;
            }
            else if (scoreType == "Perfect")
            {
                playerTwoScore += 100;
            }
        }
    }
}
