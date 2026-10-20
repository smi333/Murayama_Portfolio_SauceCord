using UnityEngine;

public class EnemyBulletMove : MonoBehaviour
{
    [SerializeField] EnemyData _enemyData;
    private float _speed;
    private float _xLimit = 10.5f;
    private float _yLimit = 6f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _speed = _enemyData.DataLists[0].BulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-1, 0, 0) * _speed * Time.deltaTime;
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
}
