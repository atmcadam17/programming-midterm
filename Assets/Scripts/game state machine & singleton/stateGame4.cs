using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* This state class is derived from State.
 * In this state, the ball moves in a random direction for a short amount of time.*/
public class stateGame4 : State
{
    private GameObject player1;
    private GameObject player2;
    
    private string instructions = "AVOID";
    private float instructionTimeOnScreen = 2;
    
    private bool gameStart = false;
    private bool introStart = false;
    
    private float speed = .16f;
    
    private Vector3 up = Vector3.up;
    private Vector3 down = Vector3.down;
    private Vector3 left = Vector3.left;
    private Vector3 right = Vector3.right;
 
    public stateGame4(gameStateManager theManager) : base(theManager) // Derived class constructor calls base class constructor.
    {

    }


    public override void Run()
    {
        if (player1 == null) // initialize stuff if null!
        {
            player1 = GameObject.FindWithTag("P1");
            Debug.Log("player 1 found: " + player1);
        }

        if (player2 == null)
        {
            player2 = GameObject.FindWithTag("P2");
            Debug.Log("player 2 found: " + player2);
        }
        
        if (gameStateManager.Instance.textObject == null)
        {
            gameStateManager.Instance.textObject = GameObject.Find("Text");;
        }
        
        if (!introStart) // run minigame intro
        {
            gameStateManager.Instance.StartCoroutine("minigameIntroCoroutine");
            introStart = true;
        }
        
        if (gameStart == false) // keep checking game start until it's true
        {
            gameStart = gameStateManager.Instance.gameStart;
        }
        else
        {
            gameStart = true;
        }

    }

    public override void Controls()
    {
        if (gameStart)
        {
            // player 1
            if (!gameStateManager.Instance.p2touchingWall)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    player1.transform.position += up * speed;
                } else if (Input.GetKey(KeyCode.S))
                {
                    player1.transform.position += down * speed;
                }
            
                if (Input.GetKey(KeyCode.A))
                {
                    player1.transform.position += left * speed;
                } else if (Input.GetKey(KeyCode.D))
                {
                    player1.transform.position += right * speed;
                }
            }
            
            // player 2
            if (!gameStateManager.Instance.p1touchingWall)
            {
                
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                player2.transform.position += up * speed;
            } else if (Input.GetKey(KeyCode.DownArrow))
            {
                player2.transform.position += down * speed;
            }
            
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                player2.transform.position += left * speed;
            } else if (Input.GetKey(KeyCode.RightArrow))
            {
                player2.transform.position += right * speed;
            }
        }
    }

    public override void Enter()
    {
        gameStateManager.Instance.instructionText = instructions;
        gameStateManager.Instance.instructionTime = instructionTimeOnScreen;

    }

    public override void Leave()
    {
        managerSingleton.Instance.currentSquare = 0;
        gameStateManager.Instance.resetMinigameIntro();
    }
}