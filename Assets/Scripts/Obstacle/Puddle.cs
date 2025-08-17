using System;
using UnityEngine;

public class Puddle : MonoBehaviour, IInteraction {

    [SerializeField] [Range(0.1f, 1)] private float _slowdown = 0.5f;

    public event Action<float> OnPlayerEnter;
    public event Action OnPlayerExit;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Ball ball))
            OnPlayerEnter?.Invoke(_slowdown);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Ball ball))
            OnPlayerExit?.Invoke();
    }
}