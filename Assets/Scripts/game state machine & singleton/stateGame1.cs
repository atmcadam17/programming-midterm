using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/* This state class is derived from State.
 * In this state, the ball moves in a random direction for a short amount of time.*/
public class stateGame1 : State
{
    private int instructionTimeOnScreen = 3;
    private string instructions = "Race to the yellow circle!";
    
    private bool gameStart = false;
    private bool introStart = false;
    private bool swapComplete = false;

    private GameObject player1;
    private GameObject player2;

    private float speed = 1;
    
    private Vector3 up = Vector3.up;
    private Vector3 down = Vector3.down;
    private Vector3 left = Vector3.left;
    private Vector3 right = Vector3.right;
    
    public stateGame1(gameStateManager theManager) : base(theManager) // Derived class constructor calls base class constructor.
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
        
        // STATE CHANGE IS IN FINISH LINE SCRIPT
    }

    public override void Collisions()
    {
        
    }

    public override void Controls()
    {
        if (gameStart)
        {
            // GAMEPLAY
            
            // direction & speed get mixed up so there r different versions of the game!

            if (!swapComplete)
            {
                int changeDirection = Random.Range(1, 4);
                switch (changeDirection)
                {
                    case 1:
                        Debug.Log("left and right swapped!");
                        var temp = left;
                        left = right;
                        right = temp;
                        Debug.Log("left: " + left);
                        Debug.Log("right: " + right);
                        break;
                    case 2:
                        Debug.Log("up and down swapped!");
                        var temp1 = up;
                        up = down;
                        down = temp1;
                        Debug.Log("up: " + up);
                        Debug.Log("down: " + down);
                        break;
                    case 3:
                        Debug.Log("speed up!");
                        speed = speed * 3.4f;
                        break;
                    case 4:
                        Debug.Log("slow down!");
                        speed = speed * .4f;
                        break;
                }
                swapComplete = true;
            }
            
            // P2 CONTROLS
            if (Input.GetKeyDown(KeyCode.W))
            {
                player2.transform.position += up * speed;
            } else if (Input.GetKeyDown(KeyCode.S))
            {
                player2.transform.position += down * speed;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                player2.transform.position += left * speed;
            } else if (Input.GetKeyDown(KeyCode.D))
            {
                player2.transform.position += right * speed;
            }
            
            // P1 CONTROLS
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                player1.transform.position += up * speed;
            } else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                player1.transform.position += down * speed;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                player1.transform.position += left * speed;
            } else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                player1.transform.position += right * speed;
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
        gameStateManager.Instance.resetMinigameIntro();
        managerSingleton.Instance.currentSquare = 0;
    }
}