using UnityEngine;

[RequireComponent (typeof(InputDetector),typeof(Rigidbody))]

public class BirdMover : MonoBehaviour
{
    [SerializeField] private float _speed = 10.0f;
    [SerializeField] private float _rotationSpeed = 10.0f;
    [SerializeField] private float _pullUpForce = 10.0f;
    [SerializeField] private float _minRotation = -45.0f;
    [SerializeField] private float _maxRotation = 45.0f;

    private InputDetector _inputDetector;
    private Rigidbody _rigidbody;
    private Quaternion _startRotation;
   
    private void OnEnable()
    {
        _inputDetector.PullUpButtonPressed += PullUp;
    }

    private void OnDisable()
    {
        _inputDetector.PullUpButtonPressed -= PullUp;
    }

    private void Awake()
    {
        _inputDetector = GetComponent<InputDetector>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _startRotation = transform.rotation;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _startRotation * Quaternion.Euler(Vector3.right * _maxRotation), _rotationSpeed * Time.deltaTime);
    }

    private void PullUp()
    {
        _rigidbody.velocity = new Vector2(_speed,_pullUpForce);
        transform.rotation = _startRotation * Quaternion.Euler(Vector3.right *  _minRotation);
    }

}
