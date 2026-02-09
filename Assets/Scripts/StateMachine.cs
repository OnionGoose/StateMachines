using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum State
    {
        Idle,
        Walking,
        Swimming,
        Climbing
    }

    public State currentState = State.Idle;
    Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState)
        {
            case State.Idle: Idle(); break;
            case State.Walking: Walking(); break;
            case State.Swimming: Swimming(); break;
            case State.Climbing: Climbing(); break;
            default: break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "WaterTrigger2")
        {
            currentState = State.Swimming;
        }
        else if(other.name == "MountainTrigger2")
        {
            currentState = State.Climbing;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        currentState = State.Walking;
    }

    void Swimming()
    {
        Debug.Log("Swimming");
    }

    void Climbing()
    {
        Debug.Log("Climbing");
    }

    void Idle()
    {
        Debug.Log("Idle");
        if (lastPosition != transform.position)
        {
            currentState = State.Walking;
        }
        lastPosition = transform.position;
    }

    void Walking()
    {
        Debug.Log("Walking");
        if (lastPosition == transform.position)
        {
            currentState = State.Idle;
        }
        lastPosition = transform.position;
    }
}
