using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Monobehaviour manager class for state machine. */
public class gameStateManager : MonoBehaviour
{
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

    // Change state.
    public void ChangeState(State newState)
    {
        if (currentState != null) currentState.Leave();
        currentState = newState;
        currentState.Enter();
    }
}
