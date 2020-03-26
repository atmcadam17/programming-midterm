using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* This state class is derived from State.
 * In this state, the ball moves in a random direction for a short amount of time.*/
public class stateBoard : State
{
 
    public stateBoard(gameStateManager theManager) : base(theManager) // Derived class constructor calls base class constructor.
    {

    }

    public override void Run()
    {
  
    }

    public override void Controls()
    {
        // p2 controls
        if (Input.GetKeyDown(KeyCode.W))
        {
            
        } else if (Input.GetKeyDown(KeyCode.S))
        {

        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            
        } else if (Input.GetKeyDown(KeyCode.D))
        {
            
        }
        
        // p1 controls
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            
        } else if (Input.GetKeyDown(KeyCode.DownArrow))
        {

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            
        } else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            
        }
    }
}