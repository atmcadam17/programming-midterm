using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerTestControls : MonoBehaviour
{
    private bool active = false;
    private float speed = .1f;
    
    private 
    
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "testScene")
        {
            active = true;
        }

        if (!active)
        {
            Destroy(this.GetComponent<playerTestControls>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.position += Vector3.up * speed;
        } else if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.position += Vector3.down * speed;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position += Vector3.left * speed;
        } else if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position += Vector3.right * speed;
        }
    }
}
