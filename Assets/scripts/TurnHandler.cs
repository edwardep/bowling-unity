using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnHandler : MonoBehaviour
{

    public Handle_score1 P1;
    public Handle_score2 P2;

    private GameManager manager;
    private int P1_frame, P2_frame;
    private bool stopGame = false;

    private void Start()
    {
        manager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
    }
    private void Update()
    {
        if(!stopGame)
            Invoke("PlayerTurns", 2);
    }
    private void PlayerTurns()
    {
        P1_frame = P1.getFrame();
        P2_frame = P2.getFrame();

        if (P1.getGO())
            P1_frame = 10;
        if (P2.getGO())
        {
            manager.Invoke("endScreen", 2);
            stopGame = true;
        }

        if ((P1_frame + P2_frame) % 2 == 0)
        {
            P1.gameObject.SetActive(true);
            P2.gameObject.SetActive(false);
        }
        else
        {
            P1.gameObject.SetActive(false);
            P2.gameObject.SetActive(true);
        }
    }
}