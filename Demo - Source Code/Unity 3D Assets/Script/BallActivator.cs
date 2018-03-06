using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BallActivator : MonoBehaviour, IInputClickHandler
{

    public GameObject ballobject;

    // Air Tap
    public void OnInputClicked(InputEventData eventData)
    {
        GameObject ball = Instantiate(ballobject) as GameObject;

        // Set the ball transform position
        ball.transform.position = Camera.main.transform.position + Camera.main.transform.forward * .90f;

        // Throwing a Random Color Ball everytime user perform AirTap
        ball.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value, 1.0f);

        // Get the rigidbody and adding velocity
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.velocity = Camera.main.transform.forward * 15 ;
        
        // Send a message To Azure whenever we throw a ball
      StartCoroutine(APIConnector.Instance.SendMessageToAzure());
    }

    // Use this for initialization
    void Start()
    {
        InputManager.Instance.PushModalInputHandler(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
