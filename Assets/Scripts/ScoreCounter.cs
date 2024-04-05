using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public event Action<int> ScoreChanged;

    [SerializeField] private BulletsTracker _bulletsTracker;

    private int _score;
    
    public int Score => _score;

    private void OnEnable()
    {
        if (_bulletsTracker)
        {
            _bulletsTracker.EnemyHit += Add;
        }
    }

    private void OnDisable()
    {
        if (_bulletsTracker)
        {
            _bulletsTracker.EnemyHit -= Add;
        }
    }

    public void Add()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    public void Reset()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
    }
}