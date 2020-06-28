using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciate : MonoBehaviour {

    public GameObject pinsPrefab;
    GameObject PinsInstance;

    void Awake()
    {
        Pins();
    }

    public void Pins()
    {
        PinsInstance = Instantiate(pinsPrefab, transform.position, Quaternion.identity) as GameObject;
        PinsInstance.name = pinsPrefab.name;
    }
}
