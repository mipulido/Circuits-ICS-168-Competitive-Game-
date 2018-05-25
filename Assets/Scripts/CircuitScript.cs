using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitScript : MonoBehaviour {

    public Transform[] pathNodes;

    LineRenderer lineRenderer;

	// Use this for initialization
	void Start () {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = pathNodes.Length;

        for (int i = 0; i < lineRenderer.positionCount; i++) {
            lineRenderer.SetPosition(i, pathNodes[i].position);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
