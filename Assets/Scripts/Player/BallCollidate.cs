using System;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class BallCollidate : MonoBehaviour 
{
    public event Action<IObstacle> Collided;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out IObstacle obj)) {
            Collided?.Invoke(obj);
        }
    }
}