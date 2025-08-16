using System;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class BallCollidate : MonoBehaviour 
{
    public event Action<IObstacle> Ñollided;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out IObstacle obj)) {
            Ñollided?.Invoke(obj);
        }
    }
}