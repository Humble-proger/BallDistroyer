using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour {
    
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        _scoreCounter.ScoreChanged += TextChanging;
    }

    private void OnDisable()
    {
        _scoreCounter.ScoreChanged -= TextChanging;
    }

    private void TextChanging(int currentScore)
    {
        _text.text = currentScore.ToString();
    }
}