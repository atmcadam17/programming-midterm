using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class createSingleton : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log(managerSingleton.Instance.name);
        Debug.Log(gameStateManager.Instance.name);
    }

    private void Update()
    {
    }
}