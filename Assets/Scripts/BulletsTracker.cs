using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Shader))]

public class BulletsTracker : MonoBehaviour
{
    public event Action<Plazma, Collider> BulletHit;
    public event Action EnemyHit;

    [SerializeField] private PlayerShooter _bird;  
    [SerializeField] private EnemyFabric _enemyFabric;
    [SerializeField] private SceneCleaner _sceneCleaner;

    private List<Plazma> _trackList = new List<Plazma>();

    public List<Plazma> TrackList => _trackList;

    private void OnEnable()
    {
        if (_bird)
        {
            _bird.BulletSpawned += TrackBullet;
        }
        
        if (_enemyFabric) 
        {
            _enemyFabric.EnemySpawned += EnemyTrack;
        }

        if (_sceneCleaner)
        {
            _sceneCleaner.BulletDestroyed += StopTrackBullet;
            _sceneCleaner.EnemyDestroyed += StopTrackEnemy;
        }
    }

    private void OnDisable()
    {
        if (_bird)
        {
            _bird.BulletSpawned -= TrackBullet;
        }

        if (_enemyFabric)
        {
            _enemyFabric.EnemySpawned -= EnemyTrack;
        }

        if (_sceneCleaner)
        {
            _sceneCleaner.BulletDestroyed -= StopTrackBullet;
            _sceneCleaner.EnemyDestroyed -= StopTrackEnemy;
        }
    }

    private void TrackBullet(Plazma bullet)
    {
        _trackList.Add(bullet);
        bullet.PlazmaHit += TranslateInfo;
    }

    private void EnemyTrack(Shooter enemy)
    {
        enemy.BulletSpawned += TrackBullet;
    }

    private void TranslateInfo(Plazma bullet, Collider collider)
    {
        BulletHit?.Invoke(bullet, collider);

        if (collider.transform.TryGetComponent<Enemy>(out _))
        {
            EnemyHit?.Invoke();
        }
    }

    private void StopTrackEnemy(Shooter enemy)
    {
        enemy.BulletSpawned -= TrackBullet;
    }

    private void StopTrackBullet(Plazma bullet)
    {
        bullet.PlazmaHit -= TranslateInfo;
        _trackList.Remove(bullet);
    }
}