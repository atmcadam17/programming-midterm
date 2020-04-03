using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* initializes the board!!! */

public class squareHolder : MonoBehaviour
{
    public List<GameObject> squares;
    public List<int> minigames;

    [SerializeField]
    private Color player1Color;
    [SerializeField]
    private Color player2Color;
    
    private List<int> player1tiles;
    private List<int> player2tiles;
    
    void Start()
    {
        // get lists of won tiles
        managerSingleton.Instance.player1tiles = player1tiles;
        managerSingleton.Instance.player2tiles = player2tiles;

        // set those tiles to each player's color
        if (player1tiles != null)
        {
            foreach (var p1tile in player1tiles)
            {
                squares[p1tile].gameObject.GetComponent<SpriteRenderer>().color = player1Color;
            }
        }

        if (player2tiles != null)
        {
            foreach (var p2tile in player2tiles)
            {
                squares[p2tile].gameObject.GetComponent<SpriteRenderer>().color = player1Color;
            }
        }
    }

    void Update()
    {
        
    }

    void selectGame(int selectedTile)
    {
        // check if the tile has already been played
        var played = false;
        if (player1tiles != null)
        {
            foreach (var p1tile in player1tiles)
            {
                if (selectedTile == p1tile)
                {
                    played = true;
                }
            }
        }

        if (player2tiles != null)
        {
            foreach (var p2tile in player1tiles)
            {
                if (selectedTile == p2tile)
                {
                    played = true;
                }
            }
        }
        
        if (played == false)
        {
            SceneManager.LoadScene(minigames[selectedTile]); // called by stateBoard, loads when player preses select
        
            // new player's turn!
            if (managerSingleton.Instance.PlayerTurn == 1)
            {
                managerSingleton.Instance.PlayerTurn = 2;
            } else if (managerSingleton.Instance.PlayerTurn == 2)
            {
                managerSingleton.Instance.PlayerTurn = 1;
            }
        
            // change state
            switch (selectedTile)
            {
                case 1:
                    gameStateManager.Instance.ChangeState(new stateGame1(gameStateManager.Instance));
                    break;
                case 2:
                    gameStateManager.Instance.ChangeState(new stateGame2(gameStateManager.Instance));
                    break;
                case 3:
                    gameStateManager.Instance.ChangeState(new stateGame3(gameStateManager.Instance));
                    break;
                case 4:
                    gameStateManager.Instance.ChangeState(new stateGame4(gameStateManager.Instance));
                    break;
                case 5:
                    gameStateManager.Instance.ChangeState(new stateGame5(gameStateManager.Instance));
                    break;
                case 6:
                    gameStateManager.Instance.ChangeState(new stateGame6(gameStateManager.Instance));
                    break;
                case 7:
                    gameStateManager.Instance.ChangeState(new stateGame7(gameStateManager.Instance));
                    break;
                case 8:
                    gameStateManager.Instance.ChangeState(new stateGame8(gameStateManager.Instance));
                    break;
                case 9:
                    gameStateManager.Instance.ChangeState(new stateGame9(gameStateManager.Instance));
                    break;
                default:
                    Debug.Log("minigame not valid");
                    break;
            }
        }
        else
        {
            Debug.Log("that tile has already been played, choose another!");
        }
    }
}
