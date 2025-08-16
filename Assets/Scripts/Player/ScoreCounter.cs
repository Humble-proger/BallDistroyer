using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int _score = 0;

    public int Score => _score;
    public event Action<int> ScoreChanged;

    public void AddScore() 
    { 
        _score++;
        ScoreChanged?.Invoke(Score);
    }

    public void Reset()
    {
       _score = 0;
        ScoreChanged?.Invoke(Score);
    }
}