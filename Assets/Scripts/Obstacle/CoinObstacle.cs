using UnityEngine;

public class CoinObstacle : MonoBehaviour, IObstacle
{
    [SerializeField] private AudioClip _coinClip;
    public void Destroy()
    {
        AudioSource.PlayClipAtPoint(_coinClip, transform.position);
        Destroy(transform.parent.gameObject);
    }
}