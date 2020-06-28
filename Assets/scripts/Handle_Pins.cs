using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle_Pins : MonoBehaviour {

    private float time = 1.5f;
    private float timer = 0f;
    private float Limit = 15f;

    public bool ended = false;
    private void Awake()
    {
    }
    private void Update()
    {
        PinFallen();
    }

    public void PinFallen()
    {
            foreach (Transform pin in transform)
            {
                if (pin)
                {
                    float angleX = pin.transform.localEulerAngles.x;
                    float angleZ = pin.transform.localEulerAngles.z;
                    angleX = (angleX > 180) ? angleX - 360 : angleX;
                    angleZ = (angleZ > 180) ? angleZ - 360 : angleZ;
                    if (Mathf.Abs(angleX) > Limit || Mathf.Abs(angleZ) > Limit)
                    { 
                        timer += Time.deltaTime;
                        if (timer > time)
                        {
                            Destroy(pin.gameObject);
                            timer = 0f;
                        }
                    }
                }
            }

    }
    public void clear()
    {
        foreach (GameObject pin in GameObject.FindGameObjectsWithTag("pin"))
        {
             Destroy(pin.gameObject);
        }
    }
}
