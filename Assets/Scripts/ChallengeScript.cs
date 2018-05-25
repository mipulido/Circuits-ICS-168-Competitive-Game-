using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChallengeScript : MonoBehaviour {

    public GameObject[] goalGates;

    public GameObject[] players;
    public bool[] playerPassedGoal;

    public Text timeCounter;
    bool challengeStarted;
    bool skippedOneFrame;
    float timeRemaining;

    int challengeType;

    void EndChallenge () {
        challengeStarted = false;

        // if was a pass goal challenge
        if (challengeType == 1)
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (!playerPassedGoal[i])
                {
                    players[i].GetComponent<PlayerHealth>().lives -= 1;
                }

                // reset array
                playerPassedGoal[i] = false;
            }
        }
        
        for (int i = 0; i < goalGates.Length; i++)
        {
            goalGates[i].SetActive(false);
        }
        Invoke("StartChallenge", Random.Range(5.0f, 15.0f));
    }

    void StartChallenge () {
        float rngGate = Random.Range(0.0f, goalGates.Length);
        float rngChallenge = Random.value;
        challengeStarted = true;

        if (rngChallenge >= 0.5f)
        {
            challengeType = 1;
            goalGates[Mathf.FloorToInt(rngGate)].GetComponent<GoalScript>().state = 1;
        }
        else
        {
            challengeType = 0;
            goalGates[Mathf.FloorToInt(rngGate)].GetComponent<GoalScript>().state = 0;
        }
        goalGates[Mathf.FloorToInt(rngGate)].SetActive(true);

        timeRemaining = 5.0f;
        skippedOneFrame = false;
        Invoke("EndChallenge", 5.0f);
    }

	// Use this for initialization
	void Start () {
        playerPassedGoal = new bool[players.Length];
        challengeStarted = false;
        skippedOneFrame = true;
        Invoke("StartChallenge", Random.Range(5.0f, 15.0f));
	}
	
	// Update is called once per frame
	void Update () {
        // update UI
        if (challengeStarted && !skippedOneFrame)
        {
            skippedOneFrame = true;
        }
        else if (challengeStarted && skippedOneFrame)
        {
            timeRemaining -= Time.deltaTime;
            timeCounter.text = "Challenge Timer:\n" + timeRemaining.ToString("F1");
        }
        else
        {
            timeCounter.text = "";
        }
        
    }
}
