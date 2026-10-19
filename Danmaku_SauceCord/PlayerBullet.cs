using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float _speed = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _speed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("衝突");
        if (collision.gameObject.CompareTag("Wall"))
            Destroy(this.gameObject);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            HPManager.instance.EnemyHPDamage();
            Destroy(this.gameObject);
        }
    }
}
