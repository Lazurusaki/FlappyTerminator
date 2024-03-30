using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Enemy : Character
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Fall()
    {
        _rigidbody.useGravity = true;
    }
}
