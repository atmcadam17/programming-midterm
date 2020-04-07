using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;


/* Monobehaviour manager class for state machine. */
public class gameStateManager : Singleton<gameStateManager>
{
    private string name = "state manager singleton";
    private State currentState;

    public string instructionText;
    public float instructionTime;
    public GameObject textObject;
    public bool gameStart = false;
    
    void Start()
    {
        gameObject.name = "state manager";
        ChangeState(new stateStart(this)); // Set initial state.
    }

    void Update()
    {
        currentState.Run();
        currentState.Controls();
    }

    private void OnCollisionEnter2D(Collision2D other)
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

    public IEnumerator minigameIntroCoroutine()
    {
        Debug.Log("intro coroutine started");
        
        if (instructionText != null && instructionTime > 0 && textObject != null)
        {
            Debug.Log("running intro");
        
            textObject.GetComponent<Text>().text = instructionText;
            yield return new WaitForSeconds(instructionTime);
            textObject.GetComponent<Text>().text = "3";
            yield return new WaitForSeconds(1);
            textObject.GetComponent<Text>().text = "2";
            yield return new WaitForSeconds(1);
            textObject.GetComponent<Text>().text = "1";
            yield return new WaitForSeconds(1);
            textObject.GetComponent<Text>().text = "START";

            gameStart = true;
            
            yield return new WaitForSeconds(1);
            textObject.GetComponent<Text>().text = "";
            yield return null;
        }
        else
        {
            Debug.Log("missing info for minigame intro");
            Debug.Log("instructions: " + instructionText);
            Debug.Log("instruction time: " + instructionTime);
            Debug.Log("text object: " + textObject);
            yield return null;
        }
    }

    public void resetMinigameIntro()
    {
        instructionText = null;
        instructionTime = 0;
        textObject = null;
        gameStart = false;
    }
}