using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField] private BallCollidate _collidate;
    [SerializeField] private ScoreCounter _scoreCounter;

    private void OnEnable()
    {
        _collidate.Collided += Collidate;
    }

    private void OnDisable()
    {
        _collidate.Collided -= Collidate;
    }

    private void Collidate(IObstacle obstacle)
    {
        _scoreCounter.AddScore();
        obstacle.Distroy();
    }
}