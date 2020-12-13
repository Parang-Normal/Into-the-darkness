using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] EnemySpawnPoint;
    public GameObject EnemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Enable()
    {
        EnemyManager.OnEnemyKilled += SpawnEnemy;
    }

    void SpawnEnemy()
    {
        int randomPoint = Mathf.RoundToInt(Random.Range(0f, EnemySpawnPoint.Length - 1));
        Instantiate(EnemyPrefab, EnemySpawnPoint[randomPoint].transform.position, EnemySpawnPoint[randomPoint].transform.rotation);
    }
}
