using UnityEngine;

[RequireComponent (typeof(Collider))]

public class SceneCleaner : MonoBehaviour
{
    [SerializeField] private Shooter _player;

    private void OnEnable()
    {
        if (_player)
        {
            _player.BulletSpawned += AddBullet;
        }
    }

    private void OnDisable()
    {
        if (_player)
        {
            _player.BulletSpawned -= AddBullet;
        }
    }

    private void AddBullet(Plazma bullet)
    {
        bullet.EnemyHit += DestroyObjects;
    }

    private void DestroyObjects(Enemy enemy, Plazma bullet)
    {
        bullet.EnemyHit -= DestroyObjects;
        Destroy(bullet.gameObject);
        Destroy(enemy.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Plazma>(out _) || other.gameObject.TryGetComponent<Enemy>(out _))
        {
            Destroy(other.gameObject);
        }
    }
}
