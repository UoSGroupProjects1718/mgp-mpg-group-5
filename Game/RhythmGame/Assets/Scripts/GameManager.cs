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

    public int playerTurn = -1;

    // Turn check bool
    public bool isPlayerOne;

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

    }
    void Start ()
    {
        // Set the first players turn
        //isPlayerOne = true;

        playerTurn = 0;

        TurnSwitch();
    }

	void Update ()
    {
        //TurnSwitch();

        if (Input.GetMouseButtonDown(0))
        {
            ClickThingToFixLater();
        }
            
    }

    public void TurnSwitch()
    {
        // Check if player 1
        if (playerTurn == 0)
        {
            //playerTwoNode.isActive = false;
            //ayerTwoNode.gameObject.SetActive(false);
            //if (playerOneNode.isActive == false)
            //{
            //    playerOneSpawner.SpawnNewNode();
            //    playerOneNode.isActive = true;
            //    custom.PickRandomCustomer();
            //}

            Destroy(currentP1Node);
            currentP1Node = playerOneSpawner.SpawnNewNode();
            custom.PickRandomCustomer();
        }
        // Check if player 2
        else if (playerTurn == 1)
        {
            //playerOneNode.isActive = false;
            //playerOneNode.gameObject.SetActive(false);
            //if (playerTwoNode.isActive == false)
            //{
            //    playerTwoSpawner.SpawnNewNode();
            //    playerTwoNode.isActive = true;
            //    custom.PickRandomCustomer();
            //}

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

    public void ClickThingToFixLater()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider)
        {
            if (hit.collider.tag == "PlayerOneTag" || hit.collider.tag == "PlayerTwoTag")
            {
                if (Customers.cust1Activator.GetComponent<Activator>().GetStatus() == true || Customers.cust2Activator.GetComponent<Activator>().GetStatus() == true)
                {
                    print("Yo?");
                    Destroy(hit.collider.gameObject);

                    if (hit.collider.gameObject.tag == "PlayerOneTag")
                    {
                        Debug.Log("WatP1");
                        ScoreManager.instance.playerOneScore += 10;
                        TurnSwitch();
                    }

                    if (hit.collider.gameObject.tag == "PlayerTwoTag")
                    {
                        Debug.Log("WatP2");
                        ScoreManager.instance.playerTwoScore += 10;
                        TurnSwitch();
                    }
                }
                else
                {
                    TurnSwitch();
                }
            }
            else
            {
                TurnSwitch();
            }
        }
        else
        {
            TurnSwitch();
        }
    }
}
