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

    public Color32 p1Color;
    public Color32 p2Color;
    
    void Start()
    {
        gameObject.name = "manager";
        p1Color = new Color32(255, 136, 136, 255);
        p2Color = new Color32(120, 229, 220, 255);
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
        Debug.Log("p1 win");
        
        if (currentSquare >= 1 && currentSquare <= 9)
        {
            switch (currentSquare)
            {
                case 1:
                    scoreKeeper.Instance.one = 1;
                    break;
                case 2:
                    scoreKeeper.Instance.two = 1;
                    break;
                case 3:
                    scoreKeeper.Instance.three = 1;
                    break;
                case 4:
                    scoreKeeper.Instance.four = 1;
                    break;
                case 5:
                    scoreKeeper.Instance.five = 1;
                    break;
                case 6:
                    scoreKeeper.Instance.six = 1;
                    break;
                case 7:
                    scoreKeeper.Instance.seven = 1;
                    break;
                case 8:
                    scoreKeeper.Instance.eight = 1;
                    break;
                case 9:
                    scoreKeeper.Instance.nine = 1;
                    break;
            }
        
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
        Debug.Log("p2 win");
        
        if (currentSquare >= 1 && currentSquare <= 9)
        {
            switch (currentSquare)
            {
                case 1:
                    scoreKeeper.Instance.one = 2;
                    break;
                case 2:
                    scoreKeeper.Instance.two = 2;
                    break;
                case 3:
                    scoreKeeper.Instance.three = 2;
                    break;
                case 4:
                    scoreKeeper.Instance.four = 2;
                    break;
                case 5:
                    scoreKeeper.Instance.five = 2;
                    break;
                case 6:
                    scoreKeeper.Instance.six = 2;
                    break;
                case 7:
                    scoreKeeper.Instance.seven = 2;
                    break;
                case 8:
                    scoreKeeper.Instance.eight = 2;
                    break;
                case 9:
                    scoreKeeper.Instance.nine = 2;
                    break;
            }
            
            currentSquare = 0;
            Debug.Log("tile added");
        }
        else
        {
            Debug.Log("error adding tile");
        }
    }
}
