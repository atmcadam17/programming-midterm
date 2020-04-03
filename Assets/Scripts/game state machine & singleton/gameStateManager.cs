using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Monobehaviour manager class for state machine. */
public class gameStateManager : Singleton<gameStateManager>
{
    private string name = "state manager singleton";
    private State currentState;
    
    void Start()
    {
        ChangeState(new stateStart(this)); // Set initial state.
    }

    void Update()
    {
        currentState.Run();
        currentState.Controls();
    }

    private void OnCollisionEnter(Collision other)
    {
        currentState.Collisions();
    }

    // Change state.
    public void ChangeState(State newState)
    {
        if (currentState != null) currentState.Leave();
        currentState = newState;
        currentState.Enter();
        Debug.Log("entering " + currentState);
    }
}