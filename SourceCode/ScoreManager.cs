using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private TextMeshProUGUI _scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _scoreText.text = $"Score : {_playerData.Score}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
