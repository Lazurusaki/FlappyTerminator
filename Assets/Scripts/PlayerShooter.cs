using UnityEngine;

[RequireComponent(typeof(InputDetector))]

public class PlayerShooter : Shooter
{
    private InputDetector _inputDetector;

    private void OnEnable()
    {
        _inputDetector.ShootButtonPressed += SpawnBullet;
    }

    private void OnDisable()
    {
        _inputDetector.ShootButtonPressed -= SpawnBullet;
    }

    private void Awake()
    {
        _inputDetector = GetComponent<InputDetector>();
    }
}
