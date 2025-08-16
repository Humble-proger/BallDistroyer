using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField] private BallCollidate _collidate;
    [SerializeField] private ScoreCounter _scoreCounter;

    private void OnEnable()
    {
        _collidate.�ollided += Collidate;
    }

    private void OnDisable()
    {
        _collidate.�ollided -= Collidate;
    }

    private void Collidate(IObstacle obstacle)
    {
        _scoreCounter.AddScore();
        obstacle.Distroy();
    }
}