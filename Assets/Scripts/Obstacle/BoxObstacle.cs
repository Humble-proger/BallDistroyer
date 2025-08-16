using UnityEngine;

public class BoxObstacle : MonoBehaviour, IObstacle
{
    [SerializeField] private AudioClip _distroyAudio;
    public void Distroy()
    {
        AudioSource.PlayClipAtPoint(_distroyAudio, transform.position);
        Destroy(gameObject);
    }
}