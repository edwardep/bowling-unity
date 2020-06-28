using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScoreBoard : MonoBehaviour {


    public GameObject scoreBoard;
    public GameObject[] score1, score2;

    private Handle_score1 scoreHandler1;
    private Handle_score2 scoreHandler2;
    private GameManager manager;

    private void Awake()
    {
        scoreHandler1 = GameObject.Find("ScoreHandler1").GetComponent<Handle_score1>();
        scoreHandler2 = GameObject.Find("ScoreHandler2").GetComponent<Handle_score2>();
        manager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
    }
    private void Update()
    {
        expandScoreBoard();
    }

    private void expandScoreBoard()
    {
        if(Input.GetKey(KeyCode.Tab) && manager.gameHasStarted())
        {
            scoreBoard.SetActive(true);
            for (int i = 0; i < score1.Length; i++)
            {
                score1[i].GetComponent<Text>().text = scoreHandler1.getOutput(i);
                score2[i].GetComponent<Text>().text = scoreHandler2.getOutput(i);
            }
        }
        else
        {
            scoreBoard.SetActive(false);
        }
    }
    
}
