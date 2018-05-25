using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Up, Down, Left, Right, UpLeft, UpRight, DownLeft, DownRight
}

public class NodeScript : MonoBehaviour {

    public int laneLevel;
    public bool laneBelowAvailable, laneAboveAvailable;
    public Direction direction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnDrawGizmos () {
        switch(laneLevel)
        {
            case 1:
                Gizmos.color = Color.yellow;
                break;
            case 2:
                Gizmos.color = Color.red;
                break;
            case 3:
                Gizmos.color = Color.green;
                break;
            case 4:
                Gizmos.color = Color.blue;
                break;
            default:
                Gizmos.color = Color.white;
                break;
        }
        Gizmos.DrawSphere(transform.position, 0.2f);
    }
}
