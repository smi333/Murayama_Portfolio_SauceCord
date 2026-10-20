using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private int _score = 0;
    private int _ball = 5;
    [SerializeField]private TextMeshProUGUI _scoreText;
    [SerializeField]private TextMeshProUGUI _ballText;
    private void Awake()
    {
        {
            instance = this;
        }
    }

    private void Start()
    {
        _score = 0;
        _ball = 5;
        _scoreText.text = "score: " + _score.ToString();
    }

    public void AddScore(int points)
    {
        _score += points;
        _scoreText.text = "score: " + _score.ToString();
    }

    public void CountBall()
    {
        _ball--;
        _ballText.text = "ball: " + _ball.ToString();
        BallController.instance.BallReset();
        if(_ball <= 0)
        {

        }
    }
}
