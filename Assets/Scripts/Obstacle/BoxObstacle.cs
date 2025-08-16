using UnityEngine;

public class BoxObstacle : MonoBehaviour, IObstacle
{
    [SerializeField] private AudioClip _distroyAudio;
    public void Destroy()
    {
        AudioSource.PlayClipAtPoint(_distroyAudio, transform.position);
        Destroy(gameObject);
    }
}