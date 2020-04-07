using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class managerSingleton : Singleton<managerSingleton>
{
    private string name = "manager singleton";
    
    public List<GameObject> tiles = null;
    public int PlayerTurn = 1;

    public int currentSquare = 0;

    public bool gameOver = false;
    public bool p1Win = false;
    public bool p2Win = false;
    
    void Start()
    {
        gameObject.name = "manager";
    }

    void Update()
    {
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        
        if (currentSquare == 0 && currentScene >= 2 && currentScene <= 10)
        {
            switch (currentScene)
            {
                    case 2:
                        currentSquare = 1;
                        break;
                    case 3:
                        currentSquare = 2;
                        break;
                    case 4:
                        currentSquare = 3;
                        break;
                    case 5:
                        currentSquare = 4;
                        break;
                    case 6:
                        currentSquare = 5;
                        break;
                    case 7:
                        currentSquare = 6;
                        break;
                    case 8:
                        currentSquare = 7;
                        break;
                    case 9:
                        currentSquare = 8;
                        break;
                    case 10:
                        currentSquare = 9;
                        break;
            }
            
            if (SceneManager.GetActiveScene().buildIndex == 5)
            {
                currentSquare = 4;
            } else if (SceneManager.GetActiveScene().buildIndex == 6)
            {
                currentSquare = 5;
            } else if (SceneManager.GetActiveScene().buildIndex == 7)
            {
                currentSquare = 6;
            } else if (SceneManager.GetActiveScene().buildIndex == 8)
            {
                currentSquare = 7;
            } else if (SceneManager.GetActiveScene().buildIndex == 9)
            {
                currentSquare = 8;
            } else if (SceneManager.GetActiveScene().buildIndex == 10)
            {
                currentSquare = 9;
            }
        }
        
        // TODO: add win condition (get 3 across!)
        if (p1Win || p2Win)
        {
            gameOver = true;
        }
        
        if (gameOver)
        {
            SceneManager.LoadScene("end");
            gameStateManager.Instance.ChangeState(new stateEnd(gameStateManager.Instance));
        }
    }

    public void addPlayer1Tile()
    {
        if (currentSquare >= 1 && currentSquare <= 9 && scoreKeeper.Instance._p1list.tiles != null)
        {
            scoreKeeper.Instance._p1list.tiles.Add(currentSquare);
        
            currentSquare = 0;
            Debug.Log("tile added");
        }
        else
        {
            Debug.Log("error adding tile");
        }
    }
    
    public void addPlayer2Tile()
    {
        if (currentSquare >= 1 && currentSquare <= 9 && scoreKeeper.Instance._p2list.tiles != null)
        {
            scoreKeeper.Instance._p2list.tiles.Add(currentSquare);
            
            currentSquare = 0;
            Debug.Log("tile added");
        }
        else
        {
            Debug.Log("error adding tile");
        }
    }
}
