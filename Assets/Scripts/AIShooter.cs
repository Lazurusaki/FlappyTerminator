using System.Collections;
using UnityEngine;

public class AIShooter : Shooter
{
    [SerializeField] float _maxWait = 2.0f;

    private void Start()
    {
        StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        WaitForSeconds wait;

        while (true)
        {
            wait = new WaitForSeconds(Random.Range(_cooldown, _maxWait));
            SpawnBullet();
            yield return wait;
        }
    }
}
