using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scoreKeeper : Singleton<scoreKeeper>
{
    public int one = 0;
    public int two = 0;
    public int three = 0;
    public int four = 0;
    public int five = 0;
    public int six = 0;
    public int seven = 0;
    public int eight = 0;
    public int nine = 0;

    private bool boardColorsChanged = false;
    private List<GameObject> squares;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "score keeper";
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "board" && squares == null)
        {
            squares = GameObject.Find("squareHolder").GetComponent<squareHolder>().squares;
        }
        else if (SceneManager.GetActiveScene().name != "board")
        {
            squares = null;
        }
        
        if (SceneManager.GetActiveScene().name == "board" && boardColorsChanged == false && squares != null)
        {
            paintTiles();
            boardColorsChanged = true;
        } else if (SceneManager.GetActiveScene().name != "board")
        {
            boardColorsChanged = false;
        }
        
        if (squares != null)
        {
            // check rows for win
            if (one != 0 && one == two && two == three)
            {
                Win(one);
            } else if (four != 0 && four == five && five == six)
            {
                Win(four);
            } else if (seven != 0 && seven == eight && eight == nine)
            {
                Win(seven);
            }
            // check columns for win
            if (one != 0 && one == four && four == seven)
            {
                Win(one);
            } else if (two != 0 && two == five && five == eight)
            {
                Win(two);
            } else if (three != 0 && three == six && six == nine)
            {
                Win(three);
            }
        
            // check diagonals for win
            if (one != 0 && one == five && five == nine)
            {
                Win(one);
            } else if (three != 0 && three == five && five == seven)
            {
                Win(three);
            }
        }
    }

    public void paintTiles()
    {
        var p1color = managerSingleton.Instance.p1Color;
        var p2color = managerSingleton.Instance.p2Color;

        if (squares != null)
        {
            //paint p1's tiles
            if (one == 1)
            {
                squares[1].GetComponent<SpriteRenderer>().color = p1color;
            }
            
            if (two == 1)
            {
                squares[2].GetComponent<SpriteRenderer>().color = p1color;
            }
            
            if (three == 1)
            {
                squares[3].GetComponent<SpriteRenderer>().color = p1color;
            }
            
            if (four == 1)
            {
                squares[4].GetComponent<SpriteRenderer>().color = p1color;
            }
            
            if (five == 1)
            {
                squares[5].GetComponent<SpriteRenderer>().color = p1color;
            }
            
            if (six == 1)
            {
                squares[6].GetComponent<SpriteRenderer>().color = p1color;
            }
            
            if (seven == 1)
            {
                squares[7].GetComponent<SpriteRenderer>().color = p1color;
            }
            
            if (eight == 1)
            {
                squares[8].GetComponent<SpriteRenderer>().color = p1color;
            } 
            
            if (nine == 1)
            {
                squares[9].GetComponent<SpriteRenderer>().color = p1color;
            }
                
           // paint p2's tiles
            if (one == 2)
            {
                squares[1].GetComponent<SpriteRenderer>().color = p2color;
            }
            
            if (two == 2)
            {
                squares[2].GetComponent<SpriteRenderer>().color = p2color;
            }
            
            if (three == 2)
            {
                squares[3].GetComponent<SpriteRenderer>().color = p2color;
            }
            
            if (four == 2)
            {
                squares[4].GetComponent<SpriteRenderer>().color = p2color;
            }
            
            if (five == 2)
            {
                squares[5].GetComponent<SpriteRenderer>().color = p2color;
            }
            
            if (six == 2)
            {
                squares[6].GetComponent<SpriteRenderer>().color = p2color;
            }
            
            if (seven == 2)
            {
                squares[7].GetComponent<SpriteRenderer>().color = p2color;
            }
            
            if (eight == 2)
            {
                squares[8].GetComponent<SpriteRenderer>().color = p2color;
            } 
            
            if (nine == 2)
            {
                squares[9].GetComponent<SpriteRenderer>().color = p2color;
            }
        }
    }

    // to win, tiles have to be the same. check whether it's 1 or 2 and update win in manager
    public void Win(int square)
    {
        if (square == 1)
        {
            managerSingleton.Instance.p1Win = true;
            Debug.Log("p1 win >:)");
        } else if (square == 2)
        {
            managerSingleton.Instance.p2Win = true;
            Debug.Log("p2 win >:)");
        }
        
        one = 0;
        two = 0;
        three = 0;
        four = 0;
        five = 0;
        six = 0;
        seven = 0;
        eight = 0;
        nine = 0;
    }
}