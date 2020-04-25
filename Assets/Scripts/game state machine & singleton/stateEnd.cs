using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/* This state class is derived from State.
 * In this state, the ball moves in a random direction for a short amount of time.*/
public class stateEnd : State
{

    private Text winText;
    
    public stateEnd(gameStateManager theManager) : base(theManager) // Derived class constructor calls base class constructor.
    {

    }

    public override void Run()
    {
        
    }

    public override void Enter()
    {
        winText = GameObject.FindWithTag("Text").GetComponent<Text>();
        if (managerSingleton.Instance.p1Win)
        {
            winText.text = "PLAYER 1 WINS";
        } else if (managerSingleton.Instance.p2Win)
        {
            winText.text = "PLAYER 2 WINS";
        }
        else
        {
            winText.text = "no one wins..........?";
        }
    }
}