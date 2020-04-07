using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* This state class is derived from State.
 * In this state, the ball moves in a random direction for a short amount of time.*/
public class stateGame2 : State
{
 
    public stateGame2(gameStateManager theManager) : base(theManager) // Derived class constructor calls base class constructor.
    {

    }

    public override void Run()
    {
        // REROUTE TO SCENE 1 (TEMPORARY)
        gameStateManager.Instance.ChangeState(new stateGame1(gameStateManager.Instance));
    }

    public override void Leave()
    {
        managerSingleton.Instance.currentSquare = 0;
    }
}