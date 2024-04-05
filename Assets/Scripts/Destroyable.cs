using System;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    public event Action<ParticleSystem> FXSpawned;

    [SerializeField] private AudioClip _destroySound;
    [SerializeField] private ParticleSystem _destroyFX;

    private void OnDestroy()
    {
        if (_destroySound)
        {
            AudioSource.PlayClipAtPoint(_destroySound, transform.position);
        }

        if (_destroyFX)
        {
            ParticleSystem fx = Instantiate(_destroyFX, transform.position, Quaternion.identity);
            FXSpawned?.Invoke(fx);
        }
    }
}
