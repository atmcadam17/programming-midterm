using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* initializes the board!!! */

public class squareHolder : MonoBehaviour
{
    public List<GameObject> squares;
    public List<int> minigames;

    void Start()
    {
        // set those tiles to each player's color

        /* if (player1tiles != null)
        {
            foreach (var p1tile in player1tiles)
            {
                if (p1tile != 0)
                {
                    squares[p1tile].gameObject.GetComponent<SpriteRenderer>().color = player1Color;
                }
            }
        }

        if (player2tiles != null)
        {
            foreach (var p2tile in player2tiles)
            {
                if (p2tile != 0)
                {
                    squares[p2tile].gameObject.GetComponent<SpriteRenderer>().color = player1Color;
                }
            }
        } */
    }

    void Update()
    {
    }

    void selectGame(int selectedTile)
    {
        // new player's turn!
        if (managerSingleton.Instance.PlayerTurn == 1)
        {
            managerSingleton.Instance.PlayerTurn = 2;
        }
        else if (managerSingleton.Instance.PlayerTurn == 2)
        {
            managerSingleton.Instance.PlayerTurn = 1;
        }

        // change state
        switch (selectedTile)
        {
            // if each tile is valid change state
            case 1:
                if (scoreKeeper.Instance.one == 0)
                {
                    gameStateManager.Instance.ChangeState(new stateGame1(gameStateManager.Instance));
                    SceneManager.LoadScene(
                        minigames[selectedTile]); // called by stateBoard, loads when player preses select
                }

                break;
            case 2:
                if (scoreKeeper.Instance.two == 0)
                {
                    gameStateManager.Instance.ChangeState(new stateGame2(gameStateManager.Instance));
                    SceneManager.LoadScene(
                        minigames[selectedTile]); // called by stateBoard, loads when player preses select
                }

                break;
            case 3:
                gameStateManager.Instance.ChangeState(new stateGame3(gameStateManager.Instance));
                SceneManager.LoadScene(
                    minigames[selectedTile]); // called by stateBoard, loads when player preses select
                break;
            case 4:
                gameStateManager.Instance.ChangeState(new stateGame4(gameStateManager.Instance));
                SceneManager.LoadScene(
                    minigames[selectedTile]); // called by stateBoard, loads when player preses select
                break;
            case 5:
                gameStateManager.Instance.ChangeState(new stateGame5(gameStateManager.Instance));
                SceneManager.LoadScene(
                    minigames[selectedTile]); // called by stateBoard, loads when player preses select
                break;
            case 6:
                gameStateManager.Instance.ChangeState(new stateGame6(gameStateManager.Instance));
                SceneManager.LoadScene(
                    minigames[selectedTile]); // called by stateBoard, loads when player preses select
                break;
            case 7:
                gameStateManager.Instance.ChangeState(new stateGame7(gameStateManager.Instance));
                SceneManager.LoadScene(
                    minigames[selectedTile]); // called by stateBoard, loads when player preses select
                break;
            case 8:
                gameStateManager.Instance.ChangeState(new stateGame8(gameStateManager.Instance));
                SceneManager.LoadScene(
                    minigames[selectedTile]); // called by stateBoard, loads when player preses select
                break;
            case 9:
                gameStateManager.Instance.ChangeState(new stateGame9(gameStateManager.Instance));
                SceneManager.LoadScene(
                    minigames[selectedTile]); // called by stateBoard, loads when player preses select
                break;
            default:
                Debug.Log("minigame not valid");
                break;
        }
    }
}