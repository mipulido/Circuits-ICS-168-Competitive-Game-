using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {
    //public GameObject winner;
    public bool isActive;
    bool hasPlayedSound;

    public Sprite winSprite, loseSprite;
    public AudioClip winClip1, winClip2, loseClip1, loseClip2;

    public float timeToRestart;

	// Use this for initialization
	void Start () {
        isActive = false;
        hasPlayedSound = false;

        transform.localScale = new Vector3(4.0f, 4.0f);
    }
	
	// Update is called once per frame
	void Update () {
        if (hasPlayedSound)
        {
            timeToRestart -= Time.deltaTime;

            if (timeToRestart <= 0.0f)
            {
                SceneManager.LoadScene("Title");
            }
        }

        if (isActive && !hasPlayedSound)
        {
            GetComponent<SpriteRenderer>().sprite = winSprite;
            GetComponent<AudioSource>().clip = winClip1;
            GetComponent<AudioSource>().Play();

            foreach (GameObject p in GetComponentInParent<GameLogicScript>().players)
            {
                p.GetComponent<PathFollowingScript>().canMove = false;
            }

            hasPlayedSound = true;
        }
    }
}
