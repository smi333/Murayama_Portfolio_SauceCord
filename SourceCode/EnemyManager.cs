using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] EnemyData _enemyData;
    [SerializeField] PlayerData _playerData;
    [SerializeField]private float HP;
    private float _speed = 3f;
    private float _xLimit = 12f;
    private float _yLimit = 6f;
    [SerializeField] List<GameObject> _items = new List<GameObject>();
    [SerializeField] GameObject _experiencePoints;//経験値
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HP = _enemyData.DataLists[0].HP;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(1, 0, 0) * _speed * Time.deltaTime;
        var currentPos = transform.position;
        currentPos.x = Mathf.Clamp(currentPos.x, -_xLimit, _xLimit);
        currentPos.y = Mathf.Clamp(currentPos.y, -_yLimit, _yLimit);
        if (transform.position.x >= _xLimit || transform.position.x <= -_xLimit)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y >= _yLimit || transform.position.y <= -_yLimit)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            HP -= _playerData.Damage;
            if (HP <= 0)
            {
                _playerData.Score += 10;
                GameManager.instance.AddScore();
                var rand = Random.Range(0, 50);
                if(rand == 0)
                {
                    Instantiate(_items[Random.Range(0, _items.Count)],transform.position,Quaternion.identity);
                }
                Instantiate(_experiencePoints, transform.position,Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
