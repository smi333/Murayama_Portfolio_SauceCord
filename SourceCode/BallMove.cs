using System.Threading;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    public static BallMove Instance;
    private Vector3 _startPos; //開始位置
    private Vector3 _targetPos; //判定位置
    private float _duration;
    private float _timer = 0;
    private bool _isMoving = false;
    //[SerializeField] private Vector2 _ballDir;
    private Rigidbody2D _rb;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void MoveTo(Vector3 startPos, Vector3 target, float time)
    {
        _startPos = startPos;
        _targetPos = target;
        _duration = time + 0.1f;
        _timer = 0f;
        _isMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isMoving) return;
        _timer += Time.deltaTime;
        float t = Mathf.Clamp01(_timer / _duration);
        transform.position = Vector3.Lerp(_startPos, _targetPos, t);
        if(t >= 1f)
        {
            _isMoving = false;
            BallSpawn.Instance._noteNum.RemoveAt(0);
            _rb.AddForce(new Vector3(4f, 25f, 0f), ForceMode2D.Impulse);
        }
        //ボタン押されたときの判定処理
    }

    public void Judge()
    {
        if(_timer >= _duration - 0.2f && _timer <= _duration)
        {
            Debug.Log(_timer);
            characterManager.Instance.Catch("CatchNormal",_duration/2);
            BallSpawn.Instance._noteNum.RemoveAt(0);
            Destroy(gameObject);
        }
        else if (_timer < _duration - 0.2f)
        {
            Debug.Log(_timer);
            return;
        }

        return;
    }
}
