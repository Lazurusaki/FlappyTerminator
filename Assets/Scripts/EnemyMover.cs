using UnityEngine;

[RequireComponent (typeof(Rigidbody))]

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 0.5f;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        _rigidbody.velocity = transform.forward * _speed;
    }
}
