using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform Player;
    public Transform[] EnemySpawnPoint;
    public List<GameObject> Enemies;
    public float radius = 10.0f;

    public GameObject EnemyPrefab;
    public int EnemyCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();

    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < Enemies.Count; i++)
        {
            if(Enemies[i].GetComponent<EnemyStats>().stats.Health <= 0)
            {
                Enemies.RemoveAt(i);
            } 
        }
    }

    void Enable()
    {
        EnemyManager.OnEnemyKilled += SpawnEnemy;
    }

    void SpawnEnemy()
    {
        for (int i = 0; i < EnemyCount; i++)
        {
            int randomPoint = Mathf.RoundToInt(Random.Range(0f, EnemySpawnPoint.Length - 1));

            Vector3 randPos = EnemySpawnPoint[randomPoint].transform.position;
            randPos.x = Random.Range(randPos.x - radius, randPos.x + radius);
            randPos.z = Random.Range(randPos.z - radius, randPos.z + radius);


            GameObject clone = Instantiate(EnemyPrefab, randPos, EnemySpawnPoint[randomPoint].transform.rotation);
            clone.GetComponent<EnemyStats>().SetTarget(Player);
            Enemies.Add(clone);
        }
    }

    public bool IsFinished()
    {
        if(Enemies.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, Vector3.one * radius * 2);
    }
}
