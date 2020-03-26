using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Abstract base class for State machine.
 * Abstract classes cannot be instantiated with new.*/
public abstract class State
{
    protected gameStateManager manager; // The manager that contains the state machine.

    public abstract void Run(); // This is abstract so it MUST be implemented in derived classes.
    public virtual void Enter() { } // Virtual so can be overriden in derived classes.
    public virtual void Leave() { }
    public virtual void Controls() {}
    public virtual void Collisions(){}

    public State(gameStateManager theManager) // Constructor that takes an argument.
    {
        manager = theManager;
    }

}
