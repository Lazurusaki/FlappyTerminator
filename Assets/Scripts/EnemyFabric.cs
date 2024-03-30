using System;
using System.Collections;
using UnityEngine;

public class EnemyFabric : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _spawnHighRange = 0.3f;
    [SerializeField] private float _minSpawnInterval = 1.0f;
    [SerializeField] private float _maxSpawnInterval = 3.0f;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private void SpawnEnemy()
    {
        Vector3 position = transform.position + (Vector3.up * UnityEngine.Random.Range(transform.position.y - _spawnHighRange, transform.position.y + _spawnHighRange)); 
        Instantiate(_enemyPrefab, position, transform.rotation);
    }

    private IEnumerator SpawnEnemies()
    {
        WaitForSeconds interval = new WaitForSeconds(UnityEngine.Random.Range(_minSpawnInterval, _maxSpawnInterval));
        while (true) 
        {
            SpawnEnemy();
            yield return interval;
        }
    }
}
