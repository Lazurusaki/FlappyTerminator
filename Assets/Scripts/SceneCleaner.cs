using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent (typeof(Collider))]

public class SceneCleaner : MonoBehaviour
{
    public event Action<Plazma> BulletDestroyed;
    public event Action<Shooter> EnemyDestroyed;

    [SerializeField] private EnemyFabric _enemyFabric;
    [SerializeField] private BulletsTracker _bulletsTracker;
   
    private void OnEnable()
    {
        if (_bulletsTracker)
        {
            _bulletsTracker.BulletHit += DestroyObjects;
        }
    }

    private void OnDisable()
    {
        if (_bulletsTracker)
        {
            _bulletsTracker.BulletHit -= DestroyObjects;
        }
    }

    private void DestroyObjects(Plazma bullet, Collider collider)
    {
        if (collider.TryGetComponent(out Shooter shooter))
        {
            BulletDestroyed?.Invoke(bullet);
            EnemyDestroyed?.Invoke(shooter);
            Destroy(bullet.gameObject);
            Destroy(shooter.gameObject);
        }       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Plazma bullet))
        {
            BulletDestroyed?.Invoke(bullet);
            Destroy(other.gameObject);
        }

        else if (other.gameObject.TryGetComponent(out Shooter shooter))
        {
            EnemyDestroyed?.Invoke(shooter);
            Destroy(other.gameObject);
        }
    }

    public void ClearScene()
    {
        if (_bulletsTracker)
        {
            while (_bulletsTracker.TrackList.Count > 0)
            {
                Plazma bullet = _bulletsTracker.TrackList.First();
                BulletDestroyed?.Invoke(bullet);
                Destroy(bullet.gameObject);
            }
        }

        if (_enemyFabric)
        {
            if (_enemyFabric.transform.childCount > 0)
            {
                int childCount = _enemyFabric.transform.childCount;

                for (int i = childCount - 1; i >= 0; i--)
                {
                    if (_enemyFabric.transform.GetChild(i).TryGetComponent(out Shooter shooter))
                    {
                        EnemyDestroyed?.Invoke(shooter);
                        Destroy(_enemyFabric.transform.GetChild(i).gameObject);
                    }
                }
            }
        }
    }
}
