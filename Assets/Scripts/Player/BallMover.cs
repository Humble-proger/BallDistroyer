using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxSpeed;

    private Rigidbody _rigidbody;
    private Vector3 _startPosition;

    public void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _startPosition = transform.position;
    }

    public void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new(horizontal, 0f, vertical);
        
        if (_rigidbody.linearVelocity.magnitude > _maxSpeed) {
            _rigidbody.linearVelocity = _rigidbody.linearVelocity.normalized * _maxSpeed;
        }
        
        _rigidbody.AddForce(_speed * direction);
    }

    public void Reset()
    {
        transform.position = _startPosition;
        _rigidbody.angularVelocity = Vector3.zero;
    }
}
