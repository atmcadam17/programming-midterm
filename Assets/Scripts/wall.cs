using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    [SerializeField] private bool upWall;
    [SerializeField] private bool downWall;
    [SerializeField] private bool leftWall;
    [SerializeField] private bool rightWall;

    private float wallBounceStrength;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
