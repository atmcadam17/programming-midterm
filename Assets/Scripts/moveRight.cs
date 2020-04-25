using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveRight : MonoBehaviour
{
    private float speed;
    
    // TODO: IMPLEMENT speed up as time passes
    private float speedModifier = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = (.12f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(speed * speedModifier, 0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("P1"))
        {
            Debug.Log("p2 win");
        } else if (other.gameObject.CompareTag("P2"))
        {
            Debug.Log("p1 win");
        }
    }
}
