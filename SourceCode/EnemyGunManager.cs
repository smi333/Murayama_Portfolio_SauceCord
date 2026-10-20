using UnityEngine;

public class EnemyGunManager : MonoBehaviour
{
    [SerializeField] EnemyData _enemyData;
    [SerializeField] GameObject _bulletPrefab;
    private float _time = 0f;
    private float _span = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        _span = _enemyData.DataLists[0].ShotSpeed; //エネミーの方
        _time += Time.deltaTime;
        if (_time >= _span)
        {
            Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
            _time = 0f;
        }
    }
}
