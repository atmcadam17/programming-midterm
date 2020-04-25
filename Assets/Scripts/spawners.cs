using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class spawners : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnerz;
    [SerializeField] private bool lineSpawner = false;
    
    private List<GameObject> bulletPool = new List<GameObject>();
    private int poolQuantity = 200; // number of objects in pool

    [SerializeField] private GameObject bulletPrefab;
    
    private float bulletSpawnCount;
    private float timer = 0;

    [SerializeField] private int yVarianceMax;
    [SerializeField] private int yVarianceMin;

    
    // Start is called before the first frame update
    void Start()
    {
        if (lineSpawner)
        {
            poolQuantity = 40;
        }
        
        bulletSpawnCount = Random.Range(.5f, .9f);
        
        timer = bulletSpawnCount;
        for (int i = 0; i < poolQuantity; i++)
        {
            var newBullet = Instantiate(bulletPrefab);
            newBullet.transform.position = new Vector3(-50, -50, 0);
            bulletPool.Add(newBullet);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStateManager.Instance.gameStart || UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "testScene")
        {
        
             if (timer <= 0)
            {
                  foreach (var spawner in spawnerz)
                  {
                      var bulletIndex = Random.Range(0, bulletPool.Count);
                      var newBullet = bulletPool[bulletIndex];
                      newBullet.transform.position = spawner.transform.position;
                      if (lineSpawner)
                      {
                          var variance = Random.Range(yVarianceMin,yVarianceMax);
                          newBullet.transform.position += new Vector3(0, variance);
                      }
                      
                     timer = bulletSpawnCount;
                  }
             }
        }
                
        timer -= Time.deltaTime;
    }
}
