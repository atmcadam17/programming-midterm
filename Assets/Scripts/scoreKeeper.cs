using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreKeeper : Singleton<scoreKeeper>
{
    public P1List _p1list;
    public P2List _p2list;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "score keeper";

        _p1list = new P1List();
        _p2list = new P2List();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}