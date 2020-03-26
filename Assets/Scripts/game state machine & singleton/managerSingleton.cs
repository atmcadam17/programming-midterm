using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class managerSingleton : Singleton<managerSingleton>
{
    private string name = "manager singleton";
    
    public List<GameObject> tiles;
    
    [SerializeField] private Scene boardScene;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // initialize tiles in list!
        if (SceneManager.GetActiveScene() == boardScene && tiles == null)
        {
            for (int i = 1; i < 9; i++)
            {
                
                Debug.Log("tile " + i + " added");
            }
        } else if (SceneManager.GetActiveScene() != boardScene && tiles != null)
        {
            tiles.Clear();
        }
    }
}
