using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Handle_score2 : MonoBehaviour{

    public Text Tscore;
    public Text Subscore;
    private Handle_Pins pins;
    private Handle_Ball ball;
    private Instanciate instanciate;
    private GameManager manager;

    private bool newRoll = true;
    private bool go = false;

    private int[] rolls = new int[24];
    private int[] subscore = new int[10];
    private string[] output = new string[10];
    private int r = 0, f = 0;  //roll and frame count
    private int pinsStanding;
    private int frame10rolls = 0;
    private int TotalScore = 0;

    private void Start()
    {
        pins = GameObject.Find("Pins").GetComponent<Handle_Pins>();
        ball = GameObject.Find("ball").GetComponent<Handle_Ball>();
        instanciate = GameObject.Find("PinsInstance").GetComponent<Instanciate>();
        manager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
    }
    private void Update()
    {
        if (manager.gameHasStarted())
        {
            if (ball.rollEnd && newRoll)
            {
                newRoll = false;
                Invoke("pinCount", 6);

            }
        }
    }

    private void pinCount()
    {

        pinsStanding = GameObject.FindGameObjectsWithTag("pin").Length;

        if (r % 2 == 1)
            rolls[r] = 10 - pinsStanding - rolls[r - 1];
        else
            rolls[r] = 10 - pinsStanding;
        displayRolls();
        TotalScore = calculateSubscore();

        if (r % 2 == 0 && r > 1) //change frame evrey 2 rolls
        {
            pins.clear();
            instanciate.Pins();
            displaySubscore();
            if (f < 9)           //stop at frame 10
                f++;
        }
        if (go)
            Debug.Log("GameOver!");
        else
            newRoll = true;
    }
    private void displayRolls()
    {
        //roll : 0
        if (rolls[r] == 0 && f < 9)
            output[f] += "- ";
        //roll : 0 in frame 10
        else if (rolls[r] == 0 && f == 9)
        {
            output[f] += " - ";
            if (rolls[f * 2] == 10)
            { //if frame 10, roll 1 was strike get bonus roll
                if (++frame10rolls == 3)
                    go = true; //gameover, no bonus roll
            }
            else
            {
                if (++frame10rolls == 2)
                    go = true;
            }
        }
        //roll : spare
        else if (r >= 1 && r % 2 == 1 && rolls[r] == 10 - rolls[r - 1] && f < 9)
            output[f] += " / ";
        //roll : spare in frame 10
        else if (r >= 1 && r % 2 == 1 && rolls[r] == 10 - rolls[r - 1] && f == 9)
        {
            output[f] += " / ";
            if (++frame10rolls == 3)
                go = true; //gameover, no bonus roll
        }
        //roll : points
        else if (rolls[r] < 10 && f < 9)
            output[f] += rolls[r] + "  ";
        //roll : points in frame 10
        else if (rolls[r] < 10 && f == 9)
        {
            output[f] += rolls[r] + " ";
            if (++frame10rolls == 3)
                go = true; //gameover, no bonus roll

        }
        //roll : strike
        else if (rolls[r] == 10 && f < 9)
        {
            r++;
            output[f] += "    X";
        }
        //roll : strike in frame 10
        else if (rolls[r] == 10 && f == 9)
        {
            r++;
            output[f] += "X ";
            if (++frame10rolls == 3)
                go = true; //gameover, no bonus roll
        }
        else
        { 
            Debug.Log("else");
        }
        r++;   
    }
    private int calculateSubscore()
    {
        int j = 0;
        int i,total = 0;

        for (i = 0; i < 10; i++)
        {
            j = 2 * i;      // roll = 2 * frame

            if (rolls[j] == 10 && rolls[j + 2] != 10)
            {
                subscore[i] = 10 + rolls[j + 2] + rolls[j + 3];
            }
            else if (rolls[j] == 10 && rolls[j + 2] == 10)
            {
                subscore[i] = rolls[j] + rolls[j + 2] + rolls[j + 4];
            }
            else if (rolls[j] + rolls[j + 1] == 10)
            {
                subscore[i] = 10 + rolls[j + 2];
            }
            else
            {
                subscore[i] = rolls[j] + rolls[j + 1];
            }
        }
        for (int k = 0; k < 10; k++)
        {
            total += subscore[k];
        }
        return total;
    }

    private void displaySubscore()
    {
        if (TotalScore < 10)
            Subscore.text += "     " + TotalScore + "     ";
        else if (TotalScore < 100)
            Subscore.text += "    " + TotalScore + "    ";
        else if (TotalScore >= 100)
            Subscore.text += "   " + TotalScore + "   ";
        Tscore.text = TotalScore.ToString();
    }
    public void Reset()
    {
        r = 0;
        f = 0;
        TotalScore = 0;
        subscore = new int[10];
        rolls = new int[24];
        subscore = new int[10];
        output = new string[10];
    }
    public int getFrame()
    {
        return f;
    }
    public string getOutput(int i)
    {
        return output[i];
    }
    public int getTotalScore()
    {
        return TotalScore;
    }
    public bool getGO()
    {
        return go;
    }
}