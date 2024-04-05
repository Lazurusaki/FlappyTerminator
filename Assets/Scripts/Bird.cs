using System;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private BirdMover _birdMover;
    private ScoreCounter _scoreCounter;
    private BirdCollisionHandler _collisionHandler;

    public event Action GameOver;

    private void Awake()
    {
        _scoreCounter = GetComponent<ScoreCounter>();
        _collisionHandler = GetComponent<BirdCollisionHandler>();
        _birdMover = GetComponent<BirdMover>();
    }

    private void OnEnable()
    {
        if (_collisionHandler)
        {
            _collisionHandler.CollisionDetected += ProcessCollision;
        }   
    }

    private void OnDisable()
    {
        if (_collisionHandler)
        {
            _collisionHandler.CollisionDetected -= ProcessCollision;
        }
    }

    private void ProcessCollision(IInteractable interactable)
    {
        GameOver?.Invoke();      
    }

    public void Reset()
    {
        _scoreCounter.Reset();
        _birdMover.Reset();
    }
}
