using System;
using UnityEngine;

public class InputDetector : MonoBehaviour
{
    public event Action PullUpButtonPressed;
    public event Action ShootButtonPressed;

    private const KeyCode PullUpButton = KeyCode.Space;
    private const KeyCode ShootButton = KeyCode.F;

    private bool _pullUp;
    private bool _attack;

    public bool PullUp => _pullUp;
    public bool Attack => _attack;


    private void Update()
    {
        if (Input.GetKeyDown(PullUpButton))
        {
            PullUpButtonPressed?.Invoke();
        }

        if (Input.GetKeyDown(ShootButton))
        {
            ShootButtonPressed?.Invoke();
        }
    }
}
