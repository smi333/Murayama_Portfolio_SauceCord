using UnityEngine;

public class BulletMoveManager : MonoBehaviour
{
    [SerializeField] private float _speed = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _speed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.up * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("衝突");
        if (collision.gameObject.CompareTag("Wall"))
            Destroy(this.gameObject);
        if (collision.gameObject.CompareTag("Player"))
        {
            HPManager.instance.PlayerHPDamage();
            Destroy(this.gameObject);
        }
    }
}
