﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* This state class is derived from State.
 * In this state, the ball moves in a random direction for a short amount of time.*/
public class stateGame4 : State
{
 
    public stateGame4(gameStateManager theManager) : base(theManager) // Derived class constructor calls base class constructor.
    {

    }

    public override void Run()
    {
  
    }
}