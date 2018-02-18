using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qteSystem : MonoBehaviour {

    public GameObject nodeToTap;
    public GameObject[] channels;
    public GameObject[] startingPoints;
    public Vector2 nextPointPosition;
    public float speed;
    public int chosenChannel;
    public int chosenChannelEnd;
    public int currentIndex;

	void Start () {
        SelectNextNode();
	}
	
	void Update () {
        //This will convert the current node position from Vector 3 to Vector 2.
        Vector2 currentNodePosition = new Vector2(nodeToTap.transform.position.x, nodeToTap.transform.position.y);

        //If the node is currently not on the next point, the node will continue on moving towards it.
        //If it is, then the next point on the path is chosen.
        if(currentNodePosition != nextPointPosition)
        {
            nodeToTap.transform.position = Vector2.MoveTowards(nodeToTap.transform.position, nextPointPosition, speed * Time.deltaTime);
        } else
        {
                SelectNextPointOnPath();
        }

        //This is supposed to imitate the tap of the player, and when the player taps, the current node will disappear and new node will be used.
        if (Input.GetMouseButton(0))
        {
            SelectNextNode();
        }
	}

    //This function will select the channel and direction from which the new node will come from.
    private void SelectNextNode()
    {
        chosenChannel = Random.Range(0, 3);
        chosenChannelEnd = Random.Range(0, 2);
        nodeToTap.transform.position = WhichStartingPoint().transform.position;
        currentIndex = chosenChannelEnd * 4;
        SelectNextPointOnPath();
    }

    //This function will select the next point on the path, dependent on the starting position and chosen channel.
    //If the current index is 2, then the next node will be selceted, because the current node has reached the middle.
    //Else it will advance towards the next point. 
    private void SelectNextPointOnPath()
    {
        GameObject allPoints = channels[chosenChannel].transform.GetChild(0).gameObject;
        GameObject nextPoint;
        if (currentIndex == 2)
        {
            SelectNextNode();
        }
        else
        {
            switch (chosenChannelEnd)
            {
                case 0:
                    nextPoint = allPoints.transform.GetChild(currentIndex + 1).gameObject;
                    currentIndex++;
                    break;
                case 1:
                    nextPoint = allPoints.transform.GetChild(currentIndex - 1).gameObject;
                    currentIndex--;
                    break;
                default:
                    nextPoint = allPoints.transform.GetChild(0).gameObject;
                    break;
            }

            nextPointPosition = nextPoint.transform.position;
        }
    }

    //This function will determine which starting point to use for the node.
    private GameObject WhichStartingPoint()
    {
        int startingPositionIndex;
        switch (chosenChannel)
        {
            case 0:
                startingPositionIndex = 0;
                break;
            case 1:
                startingPositionIndex = 2;
                break;
            case 2:
                startingPositionIndex = 4;
                break;
            default:
                startingPositionIndex = 0;
                break;
        }

        return startingPoints[startingPositionIndex + chosenChannelEnd];
    }
}
