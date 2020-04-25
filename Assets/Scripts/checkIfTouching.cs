using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* put in scenes w/ edge boundary to make sure players stay in walls */

public class checkIfTouching : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall") && this.gameObject.CompareTag("P1"))
        {
            gameStateManager.Instance.p1touchingWall = true;
        } else if (other.gameObject.CompareTag("Wall") && this.gameObject.CompareTag("P2"))
        {
            gameStateManager.Instance.p2touchingWall = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Wall") && this.gameObject.CompareTag("P1"))
        {
            gameStateManager.Instance.p1touchingWall = false;
        } else if (other.gameObject.CompareTag("Wall") && this.gameObject.CompareTag("P2"))
        {
            gameStateManager.Instance.p2touchingWall = false;
        }
    }
}
