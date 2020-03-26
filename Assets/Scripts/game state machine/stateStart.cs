using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/* This state class is derived from State.
 * In this state, the ball moves in a random direction for a short amount of time.*/
public class stateStart : State
{
 
 public stateStart(gameStateManager theManager) : base(theManager) // Derived class constructor calls base class constructor.
 {
  
 }

 public override void Run()
 {
  if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
  {
   SceneManager.LoadScene("board"); // load board
   manager.ChangeState(new stateBoard(manager)); // change state to board
  }
 }
}
