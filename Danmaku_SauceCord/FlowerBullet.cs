using UnityEngine;

public class FlowerBullet : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _span;
    [SerializeField] private float _timeElapsed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _speed = 2f;
        _span = 2f;
        _timeElapsed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.up * _speed * Time.deltaTime;
        _timeElapsed += Time.deltaTime;
        if (_timeElapsed >= _span)
        {
            for(int i = 0; i <= 8; i++)
            {
                Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, 45 * i));
            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("衝突");
        if (collision.gameObject.CompareTag("Wall"))

            Destroy(this.gameObject);
        if(collision.gameObject.CompareTag("Player"))
        {
            HPManager.instance.PlayerHPDamage();
            Destroy(this.gameObject);
        }
    }
}
