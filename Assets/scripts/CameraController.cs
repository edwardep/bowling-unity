using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private Vector3 offset = new Vector3( -10, 4, 0);
    private Vector3 desiredPosition;
    private float stopFollowing = 65;
    public Transform target;
    private GameManager manager;
    Handle_Ball ball;
    void Start()
    {
        ball = GameObject.Find("ball").GetComponent<Handle_Ball>();
        manager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
    }

    void LateUpdate()
    {
        if (manager.gameHasStarted())
        {
            if (ball.moving)
            {
                if (transform.position.x < stopFollowing)
                {
                    desiredPosition = target.transform.position + offset;
                    transform.position = desiredPosition;
                }
            }
            else
            {
                desiredPosition = target.transform.position + offset;
                transform.position = desiredPosition;
            }
        }
        
    }

    public void Reset()
    {
        transform.rotation = Quaternion.Euler(10, 90, 0);
    }
}

