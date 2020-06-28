using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {

    public GameObject cam;
    public GameObject menuUI;
    public GameObject PM;
    public GameObject gameOverUI;
    public GameObject playerTurnUI;
    public Text p1Name, p2Name, winner, winner_score, p1Turn_name, p2Turn_name, p1Turn_score, p2Turn_score;
    public Image p1_Highlight, p2_Highlight;
    public Toggle music;

    private Handle_score1 player1;
    private Handle_score2 player2;

    private bool visible = false;
    private bool gameStarted = false;

    private void Start()
    {
        player1 = GameObject.Find("ScoreHandler1").GetComponent<Handle_score1>();
        player2 = GameObject.Find("ScoreHandler2").GetComponent<Handle_score2>();
    }
    private void Update()
    {
        showMenu();
        HighlightPlayerTurn();
    }


    //GUI HANDLING FUNCTIONS
    private void showMenu()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && !visible)
        {
            cam.GetComponent<BlurEffect>().TurnOn();
            menuUI.SetActive(true);
            visible = true;
        }
        else if (Input.GetKeyUp(KeyCode.Escape) && visible)
        {
            cam.GetComponent<BlurEffect>().TurnOff();
            menuUI.SetActive(false);
            visible = false;
        }
    }

    public void endScreen()
    {
        cam.GetComponent<BlurEffect>().TurnOn();
        gameOverUI.SetActive(true);
        gameStarted = false;

        if (player1.getTotalScore() > player2.getTotalScore())
        {
            winner.text = p1Name.text;
            winner_score.text = player1.getTotalScore().ToString();
        }
        else
        {
            winner.text = p2Name.text;
            winner_score.text = player2.getTotalScore().ToString();
        }
    }

    public void setP1name(string newName)
    {
        p1Name.text = newName;
    }
    public void setP2name(string newName)
    {
        p2Name.text = newName;
    }

    public void HighlightPlayerTurn()
    {
        if (gameStarted)
        {
            playerTurnUI.SetActive(true);
            p1Turn_name.text = p1Name.text;
            p2Turn_name.text = p2Name.text;
            p1Turn_score.text = player1.getTotalScore().ToString();
            p2Turn_score.text = player2.getTotalScore().ToString();
            if (player1.gameObject.activeSelf)
            {
                p1_Highlight.GetComponent<Image>().color = new Color(255, 0, 255, 200);
                p2_Highlight.GetComponent<Image>().color = new Color(0, 0, 0, 200);
            }
            else
            {
                p2_Highlight.GetComponent<Image>().color = new Color(255, 0, 255, 200);
                p1_Highlight.GetComponent<Image>().color = new Color(0, 0, 0, 200);
            }
        }
        else
        {
            playerTurnUI.SetActive(false);
        }
    }

    //BUTTONS FUNCTIONS
    public void PlayAgainBtn()
    {
        gameStarted = true;
        gameOverUI.SetActive(false);
        player1.Reset();
        player2.Reset();
        cam.GetComponent<BlurEffect>().TurnOff();
    }
    public void StartBtn()
    {
        gameStarted = true;
        PM.SetActive(true);
        menuUI.SetActive(false);
        cam.GetComponent<BlurEffect>().TurnOff();
        cam.GetComponent<CameraController>().Reset();
    }
    public void ExitBtn()
    {
        Application.Quit();
    }
    public void MusicOnOff()
    {
        if (music.isOn)
            GetComponent<AudioSource>().mute = false;
        else
            GetComponent<AudioSource>().mute = true;
    }

    //GETTER
    public bool gameHasStarted()
    {
        return gameStarted;
    }
}
