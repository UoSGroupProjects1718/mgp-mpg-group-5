using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour {

    // Player score variables
    public int playerOneScore;
    public int playerTwoScore;

    // Reference to text component
    public Text textPlayerOne;
    public Text textPlayerTwo;

    private void Awake()
    {
        // Set up text reference
        //textPlayerOne = GetComponent<Text>();
        //textPlayerTwo = GetComponent<Text>();

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
}
