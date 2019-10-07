using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{   
    [SerializeField] private float range;
    [SerializeField] private float poolSize;
    [SerializeField] private List<GameObject> enemiesPool;
    [SerializeField] private List<GameObject> enemiesPrefabs;
    [SerializeField] private float frequency;
    
    private void Awake()
    {
        enemiesPool = new List<GameObject>();
    }

    private void Start()
    {
        InvokeRepeating("spawnEnemy", 0, frequency);
    }

    private void spawnEnemy()
    {
        Vector2 position = Random.insideUnitCircle * range;
        if (enemiesPool.Count < poolSize)
        {
            GameObject prefab = enemiesPrefabs[Random.Range(0, enemiesPrefabs.Count)];
            Instantiate(prefab, position, Quaternion.identity);
        }
    }
}
