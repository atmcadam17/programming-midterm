using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/* This state class is derived from State.
 * In this state, the ball moves in a random direction for a short amount of time.*/
public class stateBoard : State
{
    private int playerTurn = managerSingleton.Instance.PlayerTurn;
    private int selectedTile = 1;

    private Color32 highlightColor;

    private GameObject squareHolder;

    private float enterTimer = .4f;
    
    private Color prevColor = Color.white;
        
    public stateBoard(gameStateManager theManager) : base(theManager) // Derived class constructor calls base class constructor.
    {

    }

    public override void Enter()
    {
        highlightColor = new Color32(237, 117, 47, 120);
    }

    public override void Run()
    {
        // initialize tiles in list!
        if (managerSingleton.Instance.tiles == null && SceneManager.GetActiveScene().name == "board")
        {
            managerSingleton.Instance.tiles = GameObject.Find("squareHolder").GetComponent<squareHolder>().squares;
            Debug.Log("board tiles found");
        }
        
        if (enterTimer > 0)
        {
            enterTimer -= Time.deltaTime;
        }
        else
        {
            squareHolder = GameObject.Find("squareHolder");
        }

        if (managerSingleton.Instance.tiles != null && scoreKeeper.Instance != null)
        {
            scoreKeeper.Instance.paintTiles();
            managerSingleton.Instance.tiles[selectedTile].gameObject.GetComponent<SpriteRenderer>().color = highlightColor;
        }
    }

    public override void Controls()
    {
        // p1 controls
        if (playerTurn == 1)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (checkTileRange(-3))
                {
                    var selectTemp = selectedTile;
                    resetColor();
                    selectedTile -= 3;
                    getNextColor(selectTemp);
                }
            } else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (checkTileRange(+3))
                {
                    var selectTemp = selectedTile;
                    resetColor();
                    selectedTile += 3;
                    getNextColor(selectTemp);
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (checkSidewaysRange(-1) && checkTileRange(-1))
                {
                    var selectTemp = selectedTile;
                    resetColor();
                    selectedTile -= 1;
                    getNextColor(selectTemp);
                }
            } else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (checkSidewaysRange(1) && checkTileRange(1))
                {
                    var selectTemp = selectedTile;
                    resetColor();
                    selectedTile += 1;
                    getNextColor(selectTemp);
                }
            }
            
            // SELECT GAME
            if (Input.GetKeyDown(KeyCode.Return) && squareHolder != null)
            {
                squareHolder.SendMessage("selectGame", selectedTile);
            }
        }
        
        // p2 controls
        if (playerTurn == 2)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (checkTileRange(-3))
                {
                    var selectTemp = selectedTile;
                    resetColor();
                    selectedTile -= 3;
                    getNextColor(selectTemp);
                }
            } else if (Input.GetKeyDown(KeyCode.S))
            {
                if (checkTileRange(3))
                {
                    var selectTemp = selectedTile;
                    resetColor();
                    selectedTile += 3;
                    getNextColor(selectTemp);
                }
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                if (checkSidewaysRange(-1) && checkTileRange(-1))
                {
                    var selectTemp = selectedTile;
                    resetColor();
                    selectedTile -= 1;
                    getNextColor(selectTemp);
                }
            } else if (Input.GetKeyDown(KeyCode.D))
            {
                if (checkSidewaysRange(1) && checkTileRange(1))
                {
                    var selectTemp = selectedTile;
                    resetColor();
                    selectedTile += 1;
                    getNextColor(selectTemp);
                }
            }
            
            // SELECT GAME
            if (Input.GetKeyDown(KeyCode.Space))
            {
                squareHolder.SendMessage("selectGame", selectedTile);
            }
        }
    }

    public override void Leave()
    {
        managerSingleton.Instance.tiles = null;
        selectedTile = 1;
    }

    public bool checkTileRange(int num)
    {
        if (num + selectedTile >= 1 && num + selectedTile < 10)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool checkSidewaysRange(int num) // num is ALWAYS either -1 or 1, or automatically false
    {
        if (num == 1)
        {
            if (num + selectedTile != 4 && num + selectedTile != 7)
            {
                return true;
            }
            else
            {
                return false;
            }
        } else if (num == -1)
        {
            if (num + selectedTile != 3 && num + selectedTile != 6)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    // goes before the selected square moves, (before reset color every time, so color can be changed back after
    public void getNextColor(int next)
    {
        prevColor = managerSingleton.Instance.tiles[selectedTile].gameObject.GetComponent<SpriteRenderer>().color;
    }

    public bool resetColor() // put after changing selectedTile EVERY TIME
    {
        managerSingleton.Instance.tiles[selectedTile].gameObject.GetComponent<SpriteRenderer>().color = prevColor;
        return true;
    }
}