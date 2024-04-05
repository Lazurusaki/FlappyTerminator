using System;
using System.Collections;
using UnityEngine;

public class EnemyFabric : MonoBehaviour
{
    public event Action<Shooter> EnemySpawned;

    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _spawnHighRange = 0.3f;
    [SerializeField] private float _minSpawnInterval = 1.0f;
    [SerializeField] private float _maxSpawnInterval = 3.0f;

    private void Start()
    {
        if (_enemyPrefab)
        {
            StartCoroutine(SpawnEnemies());
        }
    }

    private void SpawnEnemy()
    {
        Vector3 position = transform.position + (Vector3.up * UnityEngine.Random.Range(transform.position.y - _spawnHighRange, transform.position.y + _spawnHighRange));
        Enemy enemy = Instantiate(_enemyPrefab,position,transform.rotation);
        enemy.transform.SetParent(transform);

        if (enemy.TryGetComponent(out Shooter shooter))
        {
            EnemySpawned?.Invoke(shooter);
        }
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
