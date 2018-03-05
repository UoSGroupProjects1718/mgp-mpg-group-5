using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour {

    public static ScoreManager instance = null;

    // Player score variables
    public int playerOneScore;
    public int playerTwoScore;

    // Reference to text component
    public Text textPlayerOne;
    public Text textPlayerTwo;

    //public Text popUpText;

    private void Awake()
    {
        // Check if instance is equal to null
        if (instance == null)
        {
            // If no GameManager exists, set instance to this.
            instance = this;
        }
        else if (instance != this)
        {
            // If a GameManager already exists, destroy the new GameManager
            Destroy(gameObject);
        }

        // Reset player score on awake
        playerOneScore = 0;
        playerTwoScore = 0;
    }

    void Start ()
    {
        textPlayerOne.text = "Player one score " + playerOneScore.ToString();
        textPlayerTwo.text = "Player two score " + playerTwoScore.ToString();
    }

	void Update ()
    {
        textPlayerOne.text = "Player one score " + playerOneScore.ToString();
        textPlayerTwo.text = "Player two score " + playerTwoScore.ToString();
    }

    public void AddScore(string scoreType)
    {
        if (GameManager.instance.isPlayerOne)
        {
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
        else if (!GameManager.instance.isPlayerOne)
        {
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

    // TO BE REMOVED, include in AddScore().
   /* public void UpdateString(string scoreType)
    {
        if (scoreType == "Bad")
        {
            popUpText.text = "BAD";
        }
        else if (scoreType == "Good")
        {
            popUpText.text = "GOOD";
        }
        else if (scoreType == "Perfect")
        {
            popUpText.text = "PERFECT";
        }
    }*/
}
