using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    List<GameObject> spawnedEnemies;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] List<Vector3> spawnPoints;
    [SerializeField] int numberOfEnemies;

    void Awake()
    {
        spawnedEnemies = new List<GameObject>();
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < numberOfEnemies; i++){
            GameObject tmp = spawnEnemy();
            spawnedEnemies.Add(tmp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject spawnEnemy()
    {
        int pos = Random.Range(0, spawnPoints.Count);
        Quaternion rot = new Quaternion();
        GameObject enemyObj = Instantiate(enemyPrefab, spawnPoints[pos], rot);
        Enemy enemy = enemyObj.GetComponent<Enemy>();
        enemy.player = GameObject.Find("Player");
        return enemyObj;
    }
}
