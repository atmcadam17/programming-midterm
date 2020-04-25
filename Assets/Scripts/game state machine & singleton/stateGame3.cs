using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


/* This state class is derived from State.
 * In this state, the ball moves in a random direction for a short amount of time.*/
public class stateGame3 : State
{
    private int instructionTimeOnScreen = 3;
    private string instructions = "Smash arrow keys (p1) / WASD (p2)";
    
    private bool gameStart = false;
    private bool introStart = false;
    private bool swapComplete = false;

    private GameObject player1;
    private GameObject player2;

    private int p1Score = 0;
    private int p2Score = 0;

    private float gameTimer = 10.99f;

    private Text timer;
    
    public stateGame3(gameStateManager theManager) : base(theManager) // Derived class constructor calls base class constructor.
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
        
        if (timer == null)
        {
            timer = GameObject.FindWithTag("EditorOnly").GetComponent<Text>();
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

        // print player scores
        if (!gameStart)
        {
            player1.GetComponent<Text>().text = "";
            player2.GetComponent<Text>().text = "";
            timer.text = "";
        }
        else
        {
            player1.GetComponent<Text>().text = p1Score.ToString();
            player2.GetComponent<Text>().text = p2Score.ToString();

            int timerInt = (int)gameTimer;
            timer.text = timerInt.ToString();

            gameTimer -= Time.deltaTime;
        }

        if (gameTimer <= 0)
        {
            if (p1Score > p2Score)
            {
                // p1 wins
                managerSingleton.Instance.addPlayer1Tile();
            } else if (p2Score > p1Score)
            {
                // if p2 wins
                managerSingleton.Instance.addPlayer2Tile();
            }
            
            // state & scene change
            gameStateManager.Instance.ChangeState(new stateBoard(gameStateManager.Instance));
            SceneManager.LoadScene("board");
        }
    }

    public override void Collisions()
    {
        
    }

    public override void Controls()
    {
        // get one point per key pressed
        if (gameStart)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) ||
                Input.GetKeyDown(KeyCode.D))
            {
                p2Score++;
            }
        
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow) ||
                Input.GetKeyDown(KeyCode.LeftArrow))
            {
                p1Score++;
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