using UnityEngine;

public class FlipperController : MonoBehaviour
{
    [SerializeField]private float restPosition = 0f; //待機時の角度 左10,右-10
    private float _rotatePosition = 0f;
    [SerializeField] private float _rotateDir = 1f; //回転方向　左-1, 右1
    [SerializeField] private float _speed = 3; //回転スピード
    private float hitStrength = 5f; //弾く強さ
    private float flipperDamper = 150f; // 揺れを抑える抵抗
    [SerializeField]private KeyCode _flipperButton; //左Ｖ、右Ｂ
    [SerializeField]private GameObject _flipper;
    [SerializeField] private GameObject _reboundAnchor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rotatePosition = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        //キーが押されている間は回転、離すと戻る
        if(Input.GetKey(_flipperButton))
        {
            if (_rotatePosition >= 45) return;
            
            _flipper.transform.Rotate(0f, _rotateDir * _speed, 0f * Time.deltaTime);
            _rotatePosition += _speed;

        }
        else
        {
            if (_rotatePosition <= 0) return;
            _flipper.transform.Rotate(0f, -_rotateDir * _speed, 0f * Time.deltaTime);
            _rotatePosition -= _speed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            if (Input.GetKey(_flipperButton))
            {
                Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
                if(rb != null)
                {
                    Vector3 direction = collision.transform.position - _reboundAnchor.transform.position;
                    direction.y = 0f;

                    rb.AddForce(direction.normalized * hitStrength, ForceMode.Impulse);
                }
            }
        }
    }
}
