using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chaos : MonoBehaviour
{
    /*moves the little bullets*/

    public Transform spawner;
    private Vector3 direction;
    private float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = .068f;
        direction.x = Random.Range(-speed, speed);
        direction.y = Random.Range(-speed, speed);
        direction.z = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction;
    }

    public void touchedWall()
    {
        transform.position = new Vector3(0, 0, 1);
        direction.x = Random.Range(-speed, speed);
        direction.y = Random.Range(-speed, speed);
        direction.z = 1;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("P1"))
        {
            managerSingleton.Instance.addPlayer2Tile();
            gameStateManager.Instance.ChangeState(new stateBoard(gameStateManager.Instance));
            SceneManager.LoadScene("board");

        } else if (other.gameObject.CompareTag("P2"))
        {
            managerSingleton.Instance.addPlayer1Tile();
            gameStateManager.Instance.ChangeState(new stateBoard(gameStateManager.Instance));
            SceneManager.LoadScene("board");
        }
        
        if (other.gameObject.CompareTag("Wall"))
        {
            touchedWall();
        }
    }
}
