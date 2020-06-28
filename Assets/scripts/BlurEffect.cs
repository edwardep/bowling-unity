using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class BlurEffect : MonoBehaviour {

    public void TurnOn()
    {
        GetComponent<BlurOptimized>().enabled = true;
    }
    public void TurnOff()
    {
        GetComponent<BlurOptimized>().enabled = false;
    }
}
