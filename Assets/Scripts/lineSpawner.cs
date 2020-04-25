using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnerz;
    
    private List<GameObject> bulletPool = new List<GameObject>();
    private int poolQuantity = 200;

    [SerializeField] private GameObject bulletPrefab;
    
    private float bulletSpawnCount;
    private float timer = 0;
    
    void Start()
    {
        
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
        
    }
}
