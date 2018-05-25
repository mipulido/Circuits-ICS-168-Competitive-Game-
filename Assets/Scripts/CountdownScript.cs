using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownScript : MonoBehaviour {
    float timeToStart;

    public Sprite threeSprite, twoSprite, oneSprite, goSprite;
    public AudioClip threeSound, twoSound, oneSound, goSound;
    bool saidThree, saidTwo, saidOne, saidGo;

    GameObject[] players;

	// Use this for initialization
	void Start () {
        players = GetComponentInParent<GameLogicScript>().players;
        timeToStart = 3.0f;
        saidThree = false; saidTwo = false; saidOne = false; saidGo = false;

        transform.localScale = new Vector3(2.0f, 2.0f);
    }
	
	// Update is called once per frame
	void Update () {
        if (timeToStart <= 3.0f && !saidThree)
        {
            GetComponent<SpriteRenderer>().sprite = threeSprite;
            GetComponent<AudioSource>().clip = threeSound;
            GetComponent<AudioSource>().Play();
            saidThree = true;
        }
        else if (timeToStart <= 2.0f && !saidTwo)
        {
            GetComponent<SpriteRenderer>().sprite = twoSprite;
            GetComponent<AudioSource>().clip = twoSound;
            GetComponent<AudioSource>().Play();
            saidTwo = true;
        }
        else if (timeToStart <= 1.0f && !saidOne)
        {
            GetComponent<SpriteRenderer>().sprite = oneSprite;
            GetComponent<AudioSource>().clip = oneSound;
            GetComponent<AudioSource>().Play();
            saidOne = true;
        }
        else if (timeToStart <= 0.0f && !saidGo)
        {
            GetComponent<SpriteRenderer>().sprite = goSprite;
            GetComponent<AudioSource>().clip = goSound;
            GetComponent<AudioSource>().Play();
            saidGo = true;
        }
        else if (timeToStart <= -1.0f)
        {
            foreach (GameObject p in players)
            {
                p.GetComponent<PathFollowingScript>().canMove = true;
            }
            GetComponent<SpriteRenderer>().sprite = null;
        }

        timeToStart -= Time.deltaTime;
    }
}
