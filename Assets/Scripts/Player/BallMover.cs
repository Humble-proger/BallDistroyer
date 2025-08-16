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

    public void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical);
        
        if (_rigidbody.angularVelocity.magnitude > _maxSpeed) {
            _rigidbody.angularVelocity = _rigidbody.angularVelocity.normalized * _maxSpeed;
        }
        
        _rigidbody.AddForce(_speed * direction);
    }

    public void Reset()
    {
        transform.position = _startPosition;
    }
}
