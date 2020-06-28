using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_pins_falling : MonoBehaviour {


    public AudioClip fallSound;
    private AudioSource source;

    private bool firstTime = true;
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnCollisionExit(Collision collision)
    {
        //source.PlayOneShot(fallSound[Random.Range(0, fallSound.Length)], 1F);
        if (firstTime)
        {
            source.PlayOneShot(fallSound, 1F);
            firstTime = false;
        }
    }
}
