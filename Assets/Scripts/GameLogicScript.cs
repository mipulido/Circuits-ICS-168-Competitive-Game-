using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogicScript : MonoBehaviour {
    public int startingLives;
    public GameObject[] players;

    int numberOfPlayers;
    bool[] playerAlive;
    int playersAlive;
    
    bool gameOngoing;

	// Use this for initialization
	void Start () {
        numberOfPlayers = players.Length;
        playersAlive = numberOfPlayers;
        playerAlive = new bool[numberOfPlayers];
        for (int i = 0; i < numberOfPlayers; i++)
        {
            players[i].GetComponent<PlayerHealth>().lives = startingLives;
            playerAlive[i] = true;
        }

        gameOngoing = true;
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < numberOfPlayers; i++)
        {
            if (players[i].GetComponent<PlayerHealth>().lives <= 0)
            {
                playerAlive[i] = false;
            }
        }

        playersAlive = 0;
        for (int i = 0; i < numberOfPlayers; i++)
        {
            if (playerAlive[i])
                playersAlive++;
        }

        //Debug.Log(playersAlive);

        if (playersAlive == 1)
        {
            gameOngoing = false;
            GetComponentInChildren<GameOverScript>().isActive = true;
        }
	}
}
