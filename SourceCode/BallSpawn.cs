using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    [SerializeField] private Transform _catcherPos;
    [SerializeField] private List<GameObject> _ball = new List<GameObject>();
    [SerializeField] private float _span;
    [SerializeField] private float _standSpan;
    public float bpm = 160;
    private float _oneBeatTime;
    private int _tempo = 0;
    [SerializeField] private List<AudioSource> _tempoSe = new List<AudioSource>();
    private int _noteNumNow = 0;
    public List<int> _noteNum = new List<int>();
    private bool _isPlaying = false;
    [SerializeField] private TextMeshProUGUI _countDownText;
    private int[] _noteLists =
    {
        3,4,5,6,
        8,2,2,2,
        2,2,2,2,1,2,2,2,
        2,2,2,2,1,2,2,2,
        2,0,2,0,2,0,2,2,
        2,2,2,2,2,1,2,2,
        2,2,2,2,1,2,2,2,
        2,2,2,2,1,2,2,2,
        2,2,2,2,1,2,2,2,
        2,2,2,2,2,1,2,2,
        2,0,2,0,2,0,2,2,
        2,2,2,2,1,2,2,0,
        2,0,2,2,1,2,2,2,
        2,2,2,2,2,0,2,2,
        2,0,2,0,2,0,2,0,
        2,0,2,0,1,2,2,0,
        2,0,2,0,2,0,2,0,
        2,0,2,1,2,2,2,0,
        2,0,2,2,2,1,2,0,
        1,2,2,2,2,0,2,0, //受け止めてね
        2,0,2,0,1,2,2,0, //gogo
        2,0,2,0,1,2,2,1,

        2,0,2,2,2,2,2,1,
        2,0,2,1,2,2,2,1, //届けに行く

        2,0,2,0,1,2,2,0,
        2,0,2,0,1,2,2,1,
        2,0,2,2,2,2,2,1,
        2,0,2,1,2,2,2,1,
        2,2,2,2,1,2,2,2,
        2,2,2,2,1,2,2,2,
        2,2,2,2,1,2,2,2,
        2,2,2,2,1,2,2,1,
        7,
    };
    public static BallSpawn Instance { get; private set; }

    private void Awake()
    {
        // すでにインスタンスが存在している場合は自分を破棄する
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // インスタンスを登録
        Instance = this;

        // シーンを跨いで破棄されないようにする
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        _standSpan = 0;
        _oneBeatTime = 60 / bpm;
        _span = _oneBeatTime;
        _tempo = 0;
        _noteNumNow = 0;
        _isPlaying = true;
        characterManager.Instance.PlayerAnimPlay("Rhythm", _oneBeatTime);
        EnemyManager.Instance.EnemyAnimPlay("EnemyRhythm", _oneBeatTime);
    }

    private void Update()
    {
        if (!_isPlaying) return;
        _standSpan += Time.deltaTime;
        if (_standSpan > _span)
        {
            characterManager.Instance.PlayerAnimPlay("Rhythm", _oneBeatTime);
            EnemyManager.Instance.EnemyAnimPlay("EnemyRhythm", _oneBeatTime);
            //ここにballを飛ばす処理を書く
            _standSpan = 0;
            Step(_noteLists[_noteNumNow]);
            _noteNumNow++;
        }
    }
    public void Ball(int ballnumbur)
    {
        GameObject ball = Instantiate(_ball[ballnumbur], transform.position, Quaternion.identity);
        if(ballnumbur == 0)
        {
            BallMove mover = ball.GetComponent<BallMove>();
            mover.MoveTo(transform.position, _catcherPos.position, _oneBeatTime);
            _noteNum.Add(0);
        }
        if (ballnumbur == 1)
        {
            TwoBallMove mover = ball.GetComponent<TwoBallMove>();
            mover.TwoMoveTo(transform.position, _catcherPos.position, _oneBeatTime);
            _noteNum.Add(1);
        }

    }

    private void Throw(int throwNum)
    {
        if (throwNum == 0)
        {
            EnemyManager.Instance.Throw(_oneBeatTime);
        }
        else if (throwNum == 1)
        {
            EnemyManager.Instance.TwoThrow(_oneBeatTime);
        }
        
    }

    private void Step(int num)
    {
        /*switch(_tempo)
        {
            case 0:
                PlaySE(0);
                _tempo++;
                break;
            case 1:
                PlaySE(0);
                _tempo++;
                break;
            case 2:
                PlaySE(0);
                _tempo++;
                break;
            case 3:
                PlaySE(1);
                _tempo++;
                break;
            case 4:
                PlaySE(0);
                _tempo++;
                break;
            case 5:
                PlaySE(0);
                
                _tempo++;
                break;
            case 6:
                PlaySE(0);
                _tempo++;
                break;
            case 7:
                PlaySE(1);
                _tempo = 0;
                break;
        }*/

        switch(num)
        {
            case 0:
                Throw(0);
                break;
            case 1:
                Throw(1);
                break;
            case 2:
                break;
            case 3:
                _countDownText.text = "3";
                break;
            case 4:
                _countDownText.text = "2";
                break;
            case 5:
                _countDownText.text = "1";
                break;
            case 6:
                _countDownText.text = "";
                break;
            case 7:
                _isPlaying = false;
                break;
            case 8:
                BGMManager.Instance.PlayBGM(0);
                break;
        }
    }
    private void PlaySE(int se)
    {
        _tempoSe[se].Play();
    }

}
