using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour {
    public int state = 0;
    public Sprite passSprite, doNotPassSprite;
    
    void OnTriggerEnter2D (Collider2D collision) {
        if (collision.gameObject.tag == "Player" && state == 0)
        {
            collision.gameObject.GetComponent<PlayerHealth>().lives -= 1;
        }

        if (collision.gameObject.tag == "Player" && state == 1)
        {
            for (int i = 0; i < GameObject.Find("Goals").GetComponent<ChallengeScript>().players.Length; i++)
            {
                if (collision.gameObject == GameObject.Find("Goals").GetComponent<ChallengeScript>().players[i])
                {
                    GameObject.Find("Goals").GetComponent<ChallengeScript>().playerPassedGoal[i] = true;
                }
            }
            
        }
    }

	// Use this for initialization
	void Start () {
        transform.localScale = new Vector3(5.8f, 0.8f);
	}
	
	// Update is called once per frame
	void Update () {
		if (state == 0)
        {
            GetComponent<SpriteRenderer>().sprite = doNotPassSprite;
        }
        else if (state == 1)
        {
            GetComponent<SpriteRenderer>().sprite = passSprite;
        }
	}
}
