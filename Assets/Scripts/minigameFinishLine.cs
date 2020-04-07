using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class minigameFinishLine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("P1"))
        {
            managerSingleton.Instance.addPlayer1Tile();
            SceneManager.LoadScene("board");
            gameStateManager.Instance.ChangeState(new stateBoard(gameStateManager.Instance));
        } else if (other.gameObject.CompareTag("P2"))
        {
            managerSingleton.Instance.addPlayer2Tile();
            SceneManager.LoadScene("board");
            gameStateManager.Instance.ChangeState(new stateBoard(gameStateManager.Instance));
        }
    }
}
