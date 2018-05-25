using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PathFollowingScript : MonoBehaviour {

    public GameObject circuit1, circuit2, circuit3, circuit4;
    public float speed;
    public Text speedometer;

    float topSpeed = 15.0f;

    Transform[] path;
    int pathLength;
    int passedNode, nextNode;
    float percentageToNextNode;
    float epsilon = 0.001f;                     // value used to account for potential floating point errors
                                                //  (a.k.a. how close does the position need to be to the
                                                //  next node before we say it has been passed?)
    
    public int playerNumber;
    int onLane;

    public bool canMove;

    public GameObject[] circuit2Nodes, circuit3Nodes;

    void OnTriggerEnter2D (Collider2D collision) {
        if (collision.gameObject.tag == "Player")
        {
            Vector3 direction = (path[nextNode].position - transform.position).normalized;
            Vector3 colTarget = (collision.gameObject.transform.position - transform.position).normalized;
            float angle = Mathf.Acos( Vector3.Dot(direction, colTarget) );
            if ( angle < Mathf.PI / 2.0f )
            {
                Debug.Log("COLLISION!");
                collision.gameObject.GetComponent<PathFollowingScript>().speed += speed * 1.0f;
                speed = 0.0f;
            }
            
        }
    }

	// Use this for initialization
	void Start () {
        canMove = false;

        switch (playerNumber)
        {
            case 1:
                onLane = 2;
                path = circuit2.GetComponent<CircuitScript>().pathNodes;
                break;
            case 2:
                onLane = 3;
                path = circuit3.GetComponent<CircuitScript>().pathNodes;
                break;
            default:
                onLane = 3;
                path = circuit3.GetComponent<CircuitScript>().pathNodes;
                break;
        }
        
        pathLength = path.Length;
        passedNode = 0;

        if (passedNode + 1 >= pathLength)
            nextNode = 0;
        else
            nextNode = passedNode + 1;

        transform.position = path[0].position;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 direction = path[nextNode].position - transform.position;
        float distanceToNode = direction.magnitude;
        direction.Normalize();

        Vector3 potentialMove = direction * Time.deltaTime * speed;
        float moveMagnitude = potentialMove.magnitude;
        
        // shorten the movement vector if it goes past the node we want to reach
        if (moveMagnitude > distanceToNode) {
            potentialMove *= distanceToNode / moveMagnitude;
        }
        transform.position += potentialMove;
        

        // check if a path node has been passed
        distanceToNode = (path[nextNode].position - transform.position).magnitude;
        if (distanceToNode <= epsilon)
        {
            passedNode = nextNode;

            if (passedNode + 1 >= pathLength)
                nextNode = 0;
            else
                nextNode = passedNode + 1;
        }

        // calculate percentage of the way to the next node
        distanceToNode = (path[nextNode].position - transform.position).magnitude;
        percentageToNextNode = distanceToNode / (path[nextNode].position - path[passedNode].position).magnitude;

        // player controls
        if (playerNumber == 1 && canMove) {
            if (Input.GetKeyDown(KeyCode.A) && onLane == 3) {
                /*switch(circuit3Nodes[passedNode].GetComponent<NodeScript>().direction)
                {
                    case Direction.Up:
                        transform.position = transform.position + new Vector3(-1.0f, 0.0f, 0.0f);
                        break;
                    case Direction.Down:
                        transform.position = transform.position + new Vector3( 1.0f, 0.0f, 0.0f);
                        break;
                    case Direction.Left:
                        transform.position = transform.position + new Vector3(0.0f,-1.0f, 0.0f);
                        break;
                    case Direction.Right:
                        transform.position = transform.position + new Vector3(0.0f, 1.0f, 0.0f);
                        break;
                    default:
                        break;
                }*/

                onLane = 2;
                path = circuit2.GetComponent<CircuitScript>().pathNodes;
            }
            else if (Input.GetKeyDown(KeyCode.D) && onLane == 2)
            {
                /*switch (circuit2Nodes[passedNode].GetComponent<NodeScript>().direction)
                {
                    case Direction.Up:
                        transform.position = transform.position + new Vector3(1.0f, 0.0f, 0.0f);
                        break;
                    case Direction.Down:
                        transform.position = transform.position + new Vector3(-1.0f, 0.0f, 0.0f);
                        break;
                    case Direction.Left:
                        transform.position = transform.position + new Vector3(0.0f, 1.0f, 0.0f);
                        break;
                    case Direction.Right:
                        transform.position = transform.position + new Vector3(0.0f,-1.0f, 0.0f);
                        break;
                    default:
                        break;
                }*/

                onLane = 3;
                path = circuit3.GetComponent<CircuitScript>().pathNodes;
            }

            if (Input.GetKey(KeyCode.W) && speed < topSpeed) {
                speed += 0.4f;
                if (speed > topSpeed)
                {
                    speed = topSpeed;
                }
            }
            else if ((!Input.GetKey(KeyCode.W) && speed > 0) || speed > topSpeed)
            {
                speed -= 0.4f;
                if (speed < 0)
                {
                    speed = 0;
                }
            }
        }
        else if (playerNumber == 2 && canMove)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && onLane == 3)
            {
                /*switch (circuit3Nodes[passedNode].GetComponent<NodeScript>().direction)
                {
                    case Direction.Up:
                        transform.position = transform.position + new Vector3(-1.0f, 0.0f, 0.0f);
                        break;
                    case Direction.Down:
                        transform.position = transform.position + new Vector3(1.0f, 0.0f, 0.0f);
                        break;
                    case Direction.Left:
                        transform.position = transform.position + new Vector3(0.0f, -1.0f, 0.0f);
                        break;
                    case Direction.Right:
                        transform.position = transform.position + new Vector3(0.0f, 1.0f, 0.0f);
                        break;
                    default:
                        break;
                }*/

                onLane = 2;
                path = circuit2.GetComponent<CircuitScript>().pathNodes;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && onLane == 2)
            {
                /*switch (circuit2Nodes[passedNode].GetComponent<NodeScript>().direction)
                {
                    case Direction.Up:
                        transform.position = transform.position + new Vector3(1.0f, 0.0f, 0.0f);
                        break;
                    case Direction.Down:
                        transform.position = transform.position + new Vector3(-1.0f, 0.0f, 0.0f);
                        break;
                    case Direction.Left:
                        transform.position = transform.position + new Vector3(0.0f, 1.0f, 0.0f);
                        break;
                    case Direction.Right:
                        transform.position = transform.position + new Vector3(0.0f, -1.0f, 0.0f);
                        break;
                    default:
                        break;
                }*/

                onLane = 3;
                path = circuit3.GetComponent<CircuitScript>().pathNodes;
            }

            if (Input.GetKey(KeyCode.UpArrow) && speed < topSpeed)
            {
                speed += 0.4f;
                if (speed > topSpeed)
                {
                    speed = topSpeed;
                }
            }
            else if ((!Input.GetKey(KeyCode.UpArrow) && speed > 0) || speed > topSpeed)
            {
                speed -= 0.4f;
                if (speed < 0)
                {
                    speed = 0;
                }
            }
        }

        // update UI
        speedometer.text = "Speed: " + Mathf.Floor(speed);
    }
}
