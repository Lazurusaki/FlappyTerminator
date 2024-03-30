using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Plazma : MonoBehaviour
{
    public event Action<Enemy, Plazma>EnemyHit;

    [SerializeField] private float _speed;
    [SerializeField] private AudioClip _sound;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        AudioSource.PlayClipAtPoint(_sound,transform.position);
        _rigidbody.velocity = transform.forward * _speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.Fall();
            EnemyHit?.Invoke(enemy, this);
        }
    }
}
