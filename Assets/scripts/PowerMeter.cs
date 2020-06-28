using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PowerMeter : MonoBehaviour
{
    public Image powerMeterBar;
    bool buttonPressed = false;
    
    public int sign = 1;

    [SerializeField]
    public float percentage;
    [SerializeField]
    private float currentAmount;
    [SerializeField]
    private float speed = 30;

    private GameManager manager;

    Handle_Ball ball;
    void Start()
    {
        ball = GameObject.Find("ball").GetComponent<Handle_Ball>();
        if (powerMeterBar != null)
        {
            percentage = powerMeterBar.fillAmount * 0;
        }

        manager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
    }

    public void Update()
    {
        if (!ball.moving && manager.gameHasStarted())
            InputHandler();
    }

    private void InputHandler()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            buttonPressed = true;
            //pm.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            buttonPressed = false;
            //pm.SetActive(false);
        }
        if (buttonPressed)
        {
            percentage += sign * speed;
            if (percentage >= 100 || percentage <= 0)
            {
                sign *= -1;
                percentage = ((percentage <= 0) ? 0 : 100);
            }
        }
        powerMeterBar.fillAmount = percentage / 100;
    }
}