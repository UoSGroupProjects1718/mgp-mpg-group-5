using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    // Singleton pattern to make sure only one instance of GameManager exists
    public static GameManager instance = null;

    // Reference to SpawnNode script
    public SpawnNode playerOneSpawner;
    public SpawnNode playerTwoSpawner;

    // Reference to Node script
    public Node playerOneNode;
    public Node playerTwoNode;

    [SerializeField] private GameObject currentP1Node;
    [SerializeField] private GameObject currentP2Node;

    // Reference to Customers script
    public Customers custom;

    //List of customers
    public List<GameObject> playerOneList = new List<GameObject>();
    public List<GameObject> playerTwoList = new List<GameObject>();

    public List<GameObject> playerOneSeats = new List<GameObject>();
    public List<GameObject> playerTwoSeats = new List<GameObject>();

    public Animator p1Miss, p1Hit, p2Miss, p2Hit;

    public int playerTurn = -1;

    public bool gameStarted = false;

    private int layerMask;

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
    
        // Add customers into their respective lists
        playerOneList.AddRange(GameObject.FindGameObjectsWithTag("p1Customer"));
        playerTwoList.AddRange(GameObject.FindGameObjectsWithTag("p2Customer"));

        playerOneSeats.AddRange(GameObject.FindGameObjectsWithTag("p1Seat"));
        playerTwoSeats.AddRange(GameObject.FindGameObjectsWithTag("p2Seat"));

        playerTurn = 1;

    }
    void Start ()
    {
        // Set the first players turn
        //playerTurn = 0;
        //TurnSwitch();

        // Set layerMask for raycast
        layerMask = LayerMask.NameToLayer("Node");
    }

	void Update ()
    {
        if (gameStarted == false)
        {
            TurnSwitch();
            ScoreManager.instance.playerOneScore = 0;
            ScoreManager.instance.playerTwoScore = 0;
            playerTurn = 0;
            gameStarted = true;
            //TurnSwitch();
            //playerTurn = 1;
            //TurnSwitch();
        } else if (Input.GetMouseButtonDown(0))
        {
            OnPress();
        }

        if (playerOneList.Count == 10)
        {
            EndGame();
        }
        if (playerTwoList.Count == 10)
        {
            EndGame();
        }

    }

    public void TurnSwitch()
    {
        // Check if player 1
        if (playerTurn == 1)
        {
            Destroy(currentP1Node);
            currentP1Node = playerOneSpawner.SpawnNewNode();
            custom.PickRandomCustomer();
        }
        // Check if player 2
        else if (playerTurn == 0)
        {
            Destroy(currentP2Node);
            currentP2Node = playerTwoSpawner.SpawnNewNode();
            custom.PickRandomCustomer();
        }
        else
        {
            Debug.Log("This should not be happening.");
        }

        playerTurn++;

        if (playerTurn > 1)
            playerTurn = 0;
    }

    public void EndGame()
    {
        playerTurn = 2;
    }

    public void OnPress()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 500, 1 << layerMask);

        if (hit.collider)
        {
            if (hit.collider.tag == "PlayerOneTag" || hit.collider.tag == "PlayerTwoTag")
            {
                if (Customers.cust1Activator.GetComponent<Activator>().GetStatus() == true || Customers.cust2Activator.GetComponent<Activator>().GetStatus() == true)
                {
                    Destroy(hit.collider.gameObject);

                    if (hit.collider.gameObject.tag == "PlayerOneTag")
                    {
                        ScoreManager.instance.playerOneScore += 10;                     

                        // Loop through player ones seats until a free seat is found
                        for (int j = 0; j < playerOneSeats.Count; j++)
                        {
                            bool seatCheck = playerOneSeats[j].GetComponent<Seat>().taken;
                          
                            if (seatCheck == false)
                            {
                                // Pick a random customer from player twos list
                                int i = Random.Range(0, playerTwoList.Count);

                                // Pull the gameObject and Transform
                                GameObject customerObj = playerTwoList[i];
                                Transform customerTrans = customerObj.GetComponent<Transform>();

                                Transform lookPoint = customerObj.GetComponentInChildren<Transform>().transform;

                                // Set the new transform to be that of the free seat at player ONE bar.
                                customerObj.transform.position = playerOneSeats[j].transform.position;
                                customerObj.transform.rotation = Quaternion.Euler(0f, 0f, playerOneSeats[j].transform.eulerAngles.z - 90f);
                                //customerTrans.LookAt(lookPoint, Vector2.up);

                                // Remove from player twos list and add to player one
                                playerTwoList.RemoveAt(i);
                                playerOneList.Add(customerObj);

                                print("Player two loses customer");

                                break;
                            }
                            // break;
                        }

                        p1Hit.SetTrigger("peekOut");
                        TurnSwitch();
                    }

                    if (hit.collider.gameObject.tag == "PlayerTwoTag")
                    {
                        ScoreManager.instance.playerTwoScore += 10;

                        // Loop through player two seats until a free one has been found
                        for (int j = 0; j < playerTwoSeats.Count; j++)
                        {
                            bool seatCheck = playerTwoSeats[j].GetComponent<Seat>().taken;

                            if (seatCheck == false)
                            {
                                // pick a random customer from player ones list
                                int i = Random.Range(0, playerOneList.Count);

                                // Pull the gameObject and transform
                                GameObject customerObj = playerOneList[i];
                                Transform customerTrans = customerObj.GetComponent<Transform>();

                                Transform lookPoint = customerObj.GetComponentInChildren<Transform>().transform;

                                // Set the transform to be that of the free seat at player TWO bar
                                customerObj.transform.position = playerTwoSeats[j].transform.position;
                                customerObj.transform.rotation = Quaternion.Euler(0f, 0f, playerTwoSeats[j].transform.eulerAngles.z - 90f);
                                //customerTrans.LookAt(lookPoint, Vector2.up);

                                // Remove from player one list and add into player two list
                                playerOneList.RemoveAt(i);
                                playerTwoList.Add(customerObj);

                                print("Player one loses customer");

                                break;
                            }
                            // break;
                        }

                        p2Hit.SetTrigger("peekOut");
                        TurnSwitch();
                    }
                }
                else
                {
                    if (GameManager.instance.playerTurn == 0)
                    {
                        ScoreManager.instance.playerOneScore -= 10;
                        if (gameStarted)
                        {
                            p1Miss.SetTrigger("peekOut");
                        }
                        TurnSwitch();
                    }
                    else if (GameManager.instance.playerTurn == 1)
                    {
                        ScoreManager.instance.playerTwoScore -= 10;
                        if (gameStarted)
                        {
                            p2Miss.SetTrigger("peekOut");
                        }
                        TurnSwitch();
                    }
                }
            }
            else
            {
                if (GameManager.instance.playerTurn == 0)
                {
                    ScoreManager.instance.playerOneScore -= 10;
                    if (gameStarted)
                    {
                        p1Miss.SetTrigger("peekOut");
                    }
                    TurnSwitch();
                }
                else if (GameManager.instance.playerTurn == 1)
                {
                    ScoreManager.instance.playerTwoScore -= 10;
                    if (gameStarted)
                    {
                        p2Miss.SetTrigger("peekOut");
                    }
                    TurnSwitch();
                }
            }
        }
        else
        {
            if (GameManager.instance.playerTurn == 0)
            {
                ScoreManager.instance.playerOneScore -= 10;
                if (gameStarted)
                {
                    p1Miss.SetTrigger("peekOut");
                }
                TurnSwitch();
            }
            else if (GameManager.instance.playerTurn == 1)
            {
                ScoreManager.instance.playerTwoScore -= 10;
                if (gameStarted)
                {
                    p2Miss.SetTrigger("peekOut");
                }
                TurnSwitch();
            }
        }
    }
}
