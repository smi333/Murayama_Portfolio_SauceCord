using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] private float _span;
    [SerializeField] private float _timeElapsed;
    [SerializeField] private GameObject _playerBllet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _span = 0.2f;
        _timeElapsed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        _timeElapsed += Time.deltaTime;
        if (_timeElapsed >= _span)
        {
            Instantiate(_playerBllet, transform.position, Quaternion.identity);
            _timeElapsed = 0f;
        }
    }
}
