using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxSpeed;

    private Rigidbody _rigidbody;
    private Vector3 _startPosition;
    private float _multiplySpeed;

    public void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _startPosition = transform.position;
        _multiplySpeed = _maxSpeed;
        Puddle[] puddles = FindObjectsByType<Puddle>(FindObjectsSortMode.None);
        foreach (var puddle in puddles) {
            puddle.OnPlayerEnter += ApplySlowdown;
            puddle.OnPlayerExit += ResetSpeed;
        }
    }

    private void ResetSpeed()
    {
        _multiplySpeed = _maxSpeed;
    }

    private void ApplySlowdown(float obj)
    {
        if (obj > 0f && obj < 1f) { 
            _multiplySpeed = _maxSpeed * obj;
            _rigidbody.linearVelocity *= obj;
        }
    }

    public void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new(horizontal, 0f, vertical);
        
        if (_rigidbody.linearVelocity.magnitude > _multiplySpeed) {
            _rigidbody.linearVelocity = _rigidbody.linearVelocity.normalized * _multiplySpeed;
        }
        
        _rigidbody.AddForce(_speed * direction);
    }

    public void Reset()
    {
        transform.position = _startPosition;
        _rigidbody.angularVelocity = Vector3.zero;
    }
}
