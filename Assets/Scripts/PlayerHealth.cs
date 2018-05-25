using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int lives = 3;
    public Text lifeCounter;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // update UI
        lifeCounter.text = "Lives: " + lives;

		if (lives <= 0)
        {
            gameObject.SetActive(false);
        }
	}
}
