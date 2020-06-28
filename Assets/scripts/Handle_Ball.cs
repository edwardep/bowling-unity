using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle_Ball : MonoBehaviour {

    [SerializeField]
    private float thrust = 2f;
    [SerializeField]
    private float aim = 5f;
    Rigidbody rb;
    public PowerMeter power;
    public bool moving = false;
    public bool rollEnd = false;

    private Vector3 startingPosition = new Vector3(-90, 0.8395164f, 6.8f);

    private GameManager manager;

    GameObject sweep;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        sweep = GameObject.Find("PinSweeper");
        manager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
    }
    void Update(){
        if(!moving && manager.gameHasStarted())
            InputHandler();
        if(transform.position.x > 100)
        {
            rollEnd = true;
            Invoke("Reset",1);
        }
        HiddenReset();
    }

    private void InputHandler()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            moving = true;
            rb.AddForce(transform.right * thrust * power.percentage,ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Time.deltaTime * aim);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Time.deltaTime * aim);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "PinSweeper")
        {
            Reset();
        }
    }
    public void Reset()
    {
        moving = false;
        transform.position = startingPosition;
        transform.rotation = Quaternion.identity;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        power.percentage = 0;
        rollEnd = false;
        sweep.GetComponent<Animator>().Play("Sweeper");
    }
    public void HiddenReset()
    {
        if (Input.GetKeyUp(KeyCode.F9))
            Reset();
    }
}
