using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class managerSingleton : Singleton<managerSingleton>
{
    private string name = "manager singleton";
    
    public List<GameObject> tiles;
    public int PlayerTurn = 1;

    // list of tiles each player has won
    public List<int> player1tiles = null;
    public List<int> player2tiles = null;

    public bool gameOver = false;
    public bool p1Win = false;
    public bool p2Win = false;
    
    void Start()
    {
    }

    void Update()
    {
        // initialize tiles in list!
        if (SceneManager.GetActiveScene().name == "board" && tiles == null)
        {
            tiles = GameObject.Find("squareHolder").GetComponent<squareHolder>().squares;
        } else if (SceneManager.GetActiveScene().name != "board" && tiles != null)
        {
            tiles.Clear();
        }
        
        // TODO: add win condition (if certain tile combos are achieved by either player, that's a win!)
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

    void addPlayer1Tile(int num)
    {
        player1tiles.Add(num);
    }
    
    void addPlayer2Tile(int num)
    {
        player2tiles.Add(num);
    }
}
