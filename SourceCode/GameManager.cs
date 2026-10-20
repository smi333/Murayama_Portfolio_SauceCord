using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private TextMeshProUGUI _scoreText;
    private void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        _playerData.HP = 3;
        _playerData.Damage = 1;
        _playerData.BulletSpeed = 10f;
        _playerData.ShotSpeed = 0.5f;
        _playerData.Speed = 5f;
        _playerData.Score = 0;
    }

    public void AddScore()
    {
        _scoreText.text = $"Score : {_playerData.Score.ToString()}";
    }
}
