using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class qteSystem : MonoBehaviour
{

    public GameObject[] channels;
    public float speed;

    public GameObject currentNode;
    public RectTransform nodeToMove;
    public RectTransform usedChannel;
    public Vector3 startingPosition;
    public int chosenChannel;

    public bool isPlayerOneTurn;

    public Text playerScoreOneDisplay;
    public int playerScoreOne;
    public Text playerScoreTwoDisplay;
    public int playerScoreTwo;

    public int currentEventIndex;

    public Text scoreGiven;
    public bool gameStopped;

    public Text finalMessage;

    // Use this for initialization
    void Start()
    {
        isPlayerOneTurn = true;
        gameStopped = false;
        currentEventIndex = 0;
        finalMessage.text = "";
        NextNode(currentEventIndex);
        playerScoreOne = 0;
        playerScoreTwo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Display the current score of each player.
        playerScoreOneDisplay.text = playerScoreOne.ToString();
        playerScoreTwoDisplay.text = playerScoreTwo.ToString();

        //Display the current value of the tap. NOT IN FINAL GAME!
        scoreGiven.text = CalculatePoints(nodeToMove.transform.position.y).ToString();

        //If the game is not stopped, then...
        //The node will start moving downards in the chosen channel.
        if (!gameStopped) {
            nodeToMove.transform.Translate(0f, speed * Time.deltaTime, 0f);

            //If the player presses the mouse (only for testing, will be a tap), then...
            //Depedning on which player is playing, a score value will be calculated and added to their respective scores...
            //The node from that channel will reset to the top and the next node will start falling.
            //Else if the player does not 'tap', then the node will fall until it reaches the end of the channel. Then...
            //The player gets no points, and the node is reset to the top and next node starts.
            if (Input.GetMouseButtonDown(0))
            {
                if (isPlayerOneTurn)
                {
                    playerScoreOne += CalculatePoints(nodeToMove.transform.position.y);
                }
                else
                {
                    playerScoreTwo += CalculatePoints(nodeToMove.transform.position.y);
                }
                nodeToMove.transform.position = new Vector3(startingPosition.x, 570, startingPosition.z);
                NextNode(currentEventIndex);
            }
            else if (nodeToMove.position.y < 300)
            {
                nodeToMove.transform.position = new Vector3(startingPosition.x, 570, startingPosition.z);
                NextNode(currentEventIndex);
            }
        }

        //Reset game. Only for testing.
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetGame();
        }
    }

    //This function will determine which node will play next.
    //It will randomly choose which channel the next node will fall from.
    //That node will then be selected and will have it's components selected so that they could be manipulated. 
    //The starting position for the node is also set.
    //Then depending on which player is playing, each player will have 6 chances to score points. Once player one is finished, then the second player can play.
    //Once the second player finishes, then the game will try to determien the 'winner' of the round.
    //It will also set the colour to the node, so that it's clear which player goes first.
    private void NextNode(int eventsPlayerWentThrough)
    {
        chosenChannel = Random.Range(0,3);
        currentNode = channels[chosenChannel].transform.GetChild(0).gameObject;
        nodeToMove = currentNode.GetComponent<RectTransform>();
        usedChannel = channels[chosenChannel].GetComponent<RectTransform>();
        startingPosition = new Vector3(nodeToMove.transform.position.x, 570, nodeToMove.transform.position.z);

        if (isPlayerOneTurn && eventsPlayerWentThrough == 6)
        {
            isPlayerOneTurn = false;
            currentEventIndex = 0;
        }
        else if (!isPlayerOneTurn && eventsPlayerWentThrough == 5)
        { 
            DetermineRoundWinner();
        }
        else
        {
            currentEventIndex++;
        }

        currentNode.GetComponent<Image>().color = GetPlayerColor();

    }

    //This will help set the colour for the node.
    private Color GetPlayerColor()
    {
        Color playerColor;
        if (isPlayerOneTurn)
        {
            playerColor = new Color(0, 1f, 1f);
        } else
        {
            playerColor = new Color(1f, 0, 1f);
        }
        return playerColor;
    }

    //This function will stop the game and will choose the correct message depending on the winner. 
    private void DetermineRoundWinner()
    {
        gameStopped = true;
        if (playerScoreOne == playerScoreTwo)
        {
            finalMessage.text = "Draw!";
        }
        else if (playerScoreOne > playerScoreTwo)
        {
            finalMessage.text = "Player One Wins!";
        }
        else
        {
            finalMessage.text = "Player Two Wins!";
        }
    }

    //This function will calculate the points depending on the node's position when the player taps the screen.
    //The further the player is away from the node, the less points they will get. 
    private int CalculatePoints(float currentNodePosition)
    { 
        int score = 0;
        int awayFromThreshold = (int)currentNodePosition - 375;
        if (currentNodePosition > 375)
        {
            score = 400 - (awayFromThreshold * 2);
        }
        else
        {
            score = 400 + (awayFromThreshold * 4);
        }

        return score;
    }

    //This function will reset all the variables in the game.
    private void ResetGame()
    {
        playerScoreOne = 0;
        playerScoreTwo = 0;
        finalMessage.text = "";
        isPlayerOneTurn = true;
        currentEventIndex = 0;
        gameStopped = false;
        NextNode(currentEventIndex);
    }
}
