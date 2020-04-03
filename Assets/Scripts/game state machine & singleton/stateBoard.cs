using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* This state class is derived from State.
 * In this state, the ball moves in a random direction for a short amount of time.*/
public class stateBoard : State
{
    private int playerTurn = managerSingleton.Instance.PlayerTurn;
    private int selectedTile = 1;
    
    private Color highlightColor = new Color(253, 171, 159, .5f);

    private GameObject squareHolder;

    private float enterTimer = 1.6f;
        
    public stateBoard(gameStateManager theManager) : base(theManager) // Derived class constructor calls base class constructor.
    {

    }

    public override void Run()
    {
        if (enterTimer > 0)
        {
            enterTimer -= Time.deltaTime;
        }
        else
        {
            squareHolder = GameObject.Find("squareHolder");
        }
        
        managerSingleton.Instance.tiles[selectedTile].gameObject.GetComponent<SpriteRenderer>().color = highlightColor;
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
                    resetColor(selectedTile);
                    selectedTile -= 3;
                }
            } else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (checkTileRange(+3))
                {
                    resetColor(selectedTile);
                    selectedTile += 3;
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (checkSidewaysRange(-1) && checkTileRange(-1))
                {
                    resetColor(selectedTile);
                    selectedTile -= 1;
                }
            } else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (checkSidewaysRange(1) && checkTileRange(1))
                {
                    resetColor(selectedTile);
                    selectedTile += 1;
                }
            }
            
            // SELECT GAME
            if (Input.GetKeyDown(KeyCode.Space) && squareHolder != null)
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
                    resetColor(selectedTile);
                    selectedTile -= 3;
                }
            } else if (Input.GetKeyDown(KeyCode.S))
            {
                if (checkTileRange(3))
                {
                    resetColor(selectedTile);
                    selectedTile += 3;
                }
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                if (checkSidewaysRange(-1) && checkTileRange(-1))
                {
                    resetColor(selectedTile);
                    selectedTile -= 1;
                }
            } else if (Input.GetKeyDown(KeyCode.D))
            {
                if (checkSidewaysRange(1) && checkTileRange(1))
                {
                    resetColor(selectedTile);
                    selectedTile += 1;
                }
            }
            
            // SELECT GAME
            if (Input.GetKeyDown(KeyCode.Return))
            {
                squareHolder.SendMessage("selectGame", selectedTile);
            }
        }
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

    public bool resetColor(int selected) // put before changing selectedTile EVERY TIME
    {
        managerSingleton.Instance.tiles[selectedTile].gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        return true;
    }
}