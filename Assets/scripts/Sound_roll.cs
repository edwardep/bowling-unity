using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_roll : MonoBehaviour {

    public AudioClip movingAudio;
    private AudioSource source;

    Handle_Ball ball;
    bool firstTime = true;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        ball = GameObject.Find("ball").GetComponent<Handle_Ball>();
    }

    private void Update()
    {
        if (ball.moving && firstTime)
        {
            source.PlayOneShot(movingAudio, 1F);
            firstTime = false;
        }
        if (!ball.moving)
        {
            source.Stop();
            firstTime = true;
        }
    }
}
