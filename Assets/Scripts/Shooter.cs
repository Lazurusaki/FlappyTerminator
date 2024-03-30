using System;
using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public event Action<Transform> ShooterAppeared;
    public event Action<Plazma> BulletSpawned;

    [SerializeField] private Plazma _bulletBrefab;
    [SerializeField] private Transform _spawnTransform;
    [SerializeField] protected float _cooldown = 0.1f;

    private Plazma _bullet;
    
    private Coroutine _cooldownCorountine;
    private bool _canShoot = true;

    private void Start()
    {
        ShooterAppeared?.Invoke(transform);
    }

    protected void SpawnBullet()
    {
        if (_canShoot)
        {
            _bullet = Instantiate(_bulletBrefab, _spawnTransform.position, _spawnTransform.rotation);
            BulletSpawned?.Invoke(_bullet);

            if (_cooldownCorountine != null)
            {
                StopCoroutine(_cooldownCorountine);
            }

            _cooldownCorountine = StartCoroutine(Cooldown());
        }
    }

    private IEnumerator Cooldown()
    {
        _canShoot = false;
        WaitForSeconds wait = new WaitForSeconds(_cooldown);

        while (!_canShoot) 
        {
            yield return wait;
            _canShoot = true;
        }
    }    
}
