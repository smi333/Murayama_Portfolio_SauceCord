using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _flowerBullet;
    [SerializeField] private GameObject _focusBullet;
    [SerializeField] private GameObject _focusFlowerBullet;
    [SerializeField] private float _span;
    [SerializeField] private float _timeElapsed;
    private bool _isFSMix = true; //T6F5
    private int _SixTurn = 0;
    private int _fiveTurn = 0;
    private int _eightTurn = 0;
    private int _fiveTurnBack = 4;
    private bool _isRight = true;//T=Right,F=Left
    private bool _isLeft = true;//T=Left,F=Right
    private float _angle = 5.625f;
    //[SerializeField] private float _flowerAngle = 0f;
    private int _turn = 1;
    private bool _turnRight = true;
    [SerializeField]private int _move = 0;
    private int _FreamMove = 0;
    public enum BulletMove_TYPE
    {
        None,
        Normal,
        Five,
        Six,
        FSMix,
        FiveTurn,
        SixTurn,
        FiveTurnCross,
        Turn,
        Flower,
        TurnFlower,
        FiveFlower,
        SixFlower,
        FSMixFlower,
        FocusBullet,
    }
    [SerializeField] private BulletMove_TYPE _type;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _span = 0.4f;
        _timeElapsed = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        _timeElapsed += Time.deltaTime;
        if (_timeElapsed >= _span)
        {
            /*switch (_type)
            {
                case BulletMove_TYPE.Normal:
                    NormalBullet();
                    break;
                case BulletMove_TYPE.Five:
                    FiveBullet();
                    break;
                case BulletMove_TYPE.Six:
                    SixBullet();
                    break;
                case BulletMove_TYPE.FSMix:
                    FSMix();
                    break;
                case BulletMove_TYPE.FiveTurn:
                    FiveTurn();
                    break;
                case BulletMove_TYPE.SixTurn:
                    SixTurn();
                    break;
                case BulletMove_TYPE.FiveTurnCross:
                    FiveTurn();
                    FiveTurnBack();
                    break;
                case BulletMove_TYPE.Turn:
                    Turn();
                    break;
                case BulletMove_TYPE.Flower:
                    Flower();
                    break;
                case BulletMove_TYPE.TurnFlower:
                    TurnFlower();
                    break;
                case BulletMove_TYPE.FiveFlower:
                    FiveFlower();
                    break;
                case BulletMove_TYPE.SixFlower:
                    SixFlower();
                    break;
                case BulletMove_TYPE.FSMixFlower:
                    FSMixFlower();
                    break;
                case BulletMove_TYPE:
                    FocusBullet();
                    break;
            }*/
            Move();
            /*_FreamMove++;
            if(_FreamMove == 4)
            {
                _Move++;
                _FreamMove = 0;
            }*/
            _timeElapsed = 0f;

        }
    }

    private void NormalBullet()
    {
            Debug.Log("生成");
            Instantiate(_bullet, transform.position, Quaternion.identity);
    }

    private void FiveBullet()
    {
            Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, -45f));
            Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, -22.5f));
            Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, 0f));
            Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, 22.5f));
            Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, 45f));
    }

    private void SixBullet()
    {
            Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, -56.25f));
            Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, -33.75f));
            Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, -11.25f));
            Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, 11.25f));
            Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, 33.75f));
            Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, 56.25f));
    }
    //5と6単発交互
    private void FSMix()
    {
        if(_isFSMix == true)
        {
            SixBullet();
            _isFSMix = false;
            return;
        }
        if(_isFSMix == false)
        {
            FiveBullet();
            _isFSMix = true;
            return;
        }
    }

    private void FiveTurn()
    {
        switch (_fiveTurn)
        {
            case 0:
                Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, -45f));
                _fiveTurn++;
                _isRight = false;
                break;
            case 1:
                if (_isRight == false)
                {
                    Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, -22.5f));
                    _fiveTurn++;
                }
                if (_isRight == true)
                {
                    Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, -22.5f));
                    _fiveTurn--;
                }
                break;
            case 2:
                if (_isRight == false)
                {
                    Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, 0f));
                    _fiveTurn++;
                }
                if (_isRight == true)
                {
                    Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, 0f));
                    _fiveTurn--;
                }
                break;
            case 3:
                if (_isRight == false)
                {
                    Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, 22.5f));
                    _fiveTurn++;
                }
                if (_isRight == true)
                {
                    Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, 22.5f));
                    _fiveTurn--;
                }
                break;
            case 4:
                Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, 45f));
                _fiveTurn--;
                _isRight = true;
                break;
        }
    }
    private void FiveTurnBack()
    {
        switch (_fiveTurnBack)
        {
            case 0:
                Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, -45f));
                _fiveTurnBack++;
                _isLeft = true;
                break;
            case 1:
                if (_isLeft == true)
                {
                    Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, -22.5f));
                    _fiveTurnBack++;
                }
                if (_isLeft == false)
                {
                    Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, -22.5f));
                    _fiveTurnBack--;
                }
                break;
            case 2:
                if (_isLeft == true)
                {
                    Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, 0f));
                    _fiveTurnBack++;
                }
                if (_isLeft == false)
                {
                    Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, 0f));
                    _fiveTurnBack--;
                }
                break;
            case 3:
                if (_isLeft == true)
                {
                    Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, 22.5f));
                    _fiveTurnBack++;
                }
                if (_isLeft == false)
                {
                    Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, 22.5f));
                    _fiveTurnBack--;
                }
                break;
            case 4:
                Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, 45f));
                _fiveTurnBack--;
                _isLeft = false;
                break;
        }
    }
    private void SixTurn()
    {
        switch(_SixTurn)
        {
            case 0:
                Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, -56.25f));
                _SixTurn++;
                _isRight = false;
                break;
            case 1:
                if(_isRight == false)
                {
                    Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, -33.75f));
                    _SixTurn++;
                }
                if(_isRight == true)
                {
                    Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, -33.75f));
                    _SixTurn--;
                }
                break;
            case 2:
                if(_isRight == false)
                {
                    Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, -11.25f));
                    _SixTurn++;
                }
                if(_isRight == true)
                {
                    Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, -11.25f));
                    _SixTurn--;
                }
                break;
            case 3:
                if(_isRight == false)
                {
                    Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, 11.25f));
                    _SixTurn++;
                }
                if(_isRight == true)
                {
                    Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, 11.25f));
                    _SixTurn--;
                }
                break;
            case 4:
                if(_isRight == false)
                {
                    Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, 33.75f));
                    _SixTurn++;
                }
                if(_isRight == true)
                {
                    Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, 33.75f));
                    _SixTurn--;
                }
                break;
            case 5:
                Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, 56.25f));
                _SixTurn--;
                _isRight = true;
                break;
        }
    }

    private void Turn()
    {
        var turn = _angle * _turn;
        switch(_turn)
        {
            case -5:
                _turn++;
                _turnRight = true;
                break;
            case -4:
                if (_turnRight == true) _turn++;
                if (_turnRight == false) _turn--;
                break;
            case -3:
                if (_turnRight == true) _turn++;
                if (_turnRight == false) _turn--;
                break;
            case -2:
                if (_turnRight == true) _turn++;
                if (_turnRight == false) _turn--;
                break;
            case -1:
                if (_turnRight == true) _turn++;
                if (_turnRight == false) _turn--;
                break;
            case 0:
                if (_turnRight == true) _turn++;
                if (_turnRight == false) _turn--;
                break;
            case 1:
                if (_turnRight == true) _turn++;
                if (_turnRight == false) _turn--;
                break;
            case 2:
                if (_turnRight == true) _turn++;
                if (_turnRight == false) _turn--;
                break;
            case 3:
                if (_turnRight == true) _turn++;
                if (_turnRight == false) _turn--;
                break;
            case 4:
                if (_turnRight == true) _turn++;
                if (_turnRight == false) _turn--;
                break;
            case 5:
                _turn--;
                _turnRight = false;
                break;
        }
        Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, -56.25f + turn));
        Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, -33.75f + turn));
        Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, -11.25f + turn));
        Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, 11.25f + turn));
        Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, 33.75f + turn));
        Instantiate(_bullet, transform.position, Quaternion.Euler(0f, 0f, 56.25f + turn));
    }

    private void Flower()
    {
        Instantiate(_flowerBullet, transform.position, Quaternion.Euler(0f, 0f, 0f));
    }
    private void TurnFlower()
    {
        switch (_eightTurn)
        {
            case 0:
                Instantiate(_flowerBullet, transform.position, Quaternion.Euler(0f, 0f, -78.75f));
                _eightTurn++;
                _isRight = false;
                break;
            case 1:
                if (_isRight == false)
                {
                    Instantiate(_flowerBullet, transform.position, Quaternion.Euler(0f, 0f, -56.25f));
                    _eightTurn++;
                }
                if (_isRight == true)
                {
                    Instantiate(_flowerBullet, transform.position, Quaternion.Euler(0f, 0f, -56.25f));
                    _eightTurn--;
                }
                break;
            case 2:
                if (_isRight == false)
                {
                    Instantiate(_flowerBullet, transform.position, Quaternion.Euler(0f, 0f, -33.75f));
                    _eightTurn++;
                }
                if (_isRight == true)
                {
                    Instantiate(_flowerBullet, transform.position, Quaternion.Euler(0f, 0f, -33.75f));
                    _eightTurn--;
                }
                break;
            case 3:
                if (_isRight == false)
                {
                    Instantiate(_flowerBullet, transform.position, Quaternion.Euler(0f, 0f, -11.25f));
                    _eightTurn++;
                }
                if (_isRight == true)
                {
                    Instantiate(_flowerBullet, transform.position, Quaternion.Euler(0f, 0f, -11.25f));
                    _eightTurn--;
                }
                break;
            case 4:
                if (_isRight == false)
                {
                    Instantiate(_flowerBullet, transform.position, Quaternion.Euler(0f, 0f, 11.25f));
                    _eightTurn++;
                }
                if (_isRight == true)
                {
                    Instantiate(_flowerBullet, transform.position, Quaternion.Euler(0f, 0f, 11.25f));
                    _eightTurn--;
                }
                break;
            case 5:
                if (_isRight == false)
                {
                    Instantiate(_flowerBullet, transform.position, Quaternion.Euler(0f, 0f, 33.75f));
                    _eightTurn++;
                }
                if (_isRight == true)
                {
                    Instantiate(_flowerBullet, transform.position, Quaternion.Euler(0f, 0f, 33.75f));
                    _eightTurn--;
                }
                break;
            case 6:
                if (_isRight == false)
                {
                    Instantiate(_flowerBullet, transform.position, Quaternion.Euler(0f, 0f, 56.25f));
                    _eightTurn++;
                }
                if (_isRight == true)
                {
                    Instantiate(_flowerBullet, transform.position, Quaternion.Euler(0f, 0f, 56.25f));
                    _eightTurn--;
                }
                break;
            case 7:
                Instantiate(_flowerBullet, transform.position, Quaternion.Euler(0f, 0f, 78.75f));
                _eightTurn--;
                _isRight = true;
                break;
        }
    }
    private void FiveFlower()
    {
        Instantiate(_flowerBullet, transform.position, Quaternion.Euler(0f, 0f, -45f));
        Instantiate(_flowerBullet, transform.position, Quaternion.Euler(0f, 0f, -22.5f));
        Instantiate(_flowerBullet, transform.position, Quaternion.Euler(0f, 0f, 0f));
        Instantiate(_flowerBullet, transform.position, Quaternion.Euler(0f, 0f, 22.5f));
        Instantiate(_flowerBullet, transform.position, Quaternion.Euler(0f, 0f, 45f));
    }
    private void SixFlower()
    {
        Instantiate(_flowerBullet, transform.position, Quaternion.Euler(0f, 0f, -56.25f));
        Instantiate(_flowerBullet, transform.position, Quaternion.Euler(0f, 0f, -33.75f));
        Instantiate(_flowerBullet, transform.position, Quaternion.Euler(0f, 0f, -11.25f));
        Instantiate(_flowerBullet, transform.position, Quaternion.Euler(0f, 0f, 11.25f));
        Instantiate(_flowerBullet, transform.position, Quaternion.Euler(0f, 0f, 33.75f));
        Instantiate(_flowerBullet, transform.position, Quaternion.Euler(0f, 0f, 56.25f));
    }
    private void FSMixFlower()
    {
        if (_isFSMix == true)
        {
            SixFlower();
            _isFSMix = false;
            return;
        }
        if (_isFSMix == false)
        {
            FiveFlower();
            _isFSMix = true;
            return;
        }
    }
    private void FocusBullet()
    {
        Instantiate(_focusBullet, transform.position, Quaternion.Euler(0f, 0f, -45f));
        Instantiate(_focusBullet, transform.position, Quaternion.Euler(0f, 0f, -22.5f));
        Instantiate(_focusBullet, transform.position, Quaternion.Euler(0f, 0f, 0f));
        Instantiate(_focusBullet, transform.position, Quaternion.Euler(0f, 0f, 22.5f));
        Instantiate(_focusBullet, transform.position, Quaternion.Euler(0f, 0f, 45f));
    }
    private void FocusFlowerBullet()
    {
        Instantiate(_focusFlowerBullet, transform.position, Quaternion.identity);
    }

    private void Move()
    {
        if(_move == 0)
        {
            SoundManager.instance.BGM();
        }
        if (_move <= 16)
        {
            Turn();
            _move++;
            return;
        }
        if(_move <= 24)
        {
            TurnFlower();
            _move++;
            return;
        }
        if(_move <= 28)
        {
            _move++;
            return;
        }
        if(_move <= 32)
        {
            FiveBullet();
            _move++;
            return;
        }
        if(_move <= 36)
        {
            FSMix();
            _move++;
            return;
        }
        if(_move <= 40)
        {
            FiveFlower();
            _move++;
            return;
        }

        if(_move <= 44)
        {
            FSMix();
            _move++;
            return;
        }
        if(_move <= 45)
        {
            Flower();
            _move++;
            return;
        }
        if(_move <= 48)
        {
            _move++;
            return;
        }
        if(_move <= 56)
        {
            Turn();
            _move++;
            return;
        }
        if(_move <= 60)
        {
            SixFlower();
            _move++;
            return;
        }
        if(_move <= 64)
        {
            _move++;
            return;
        }
        if(_move <= 76)
        {
            FSMix();
            _move++;
            return;
        }
        if(_move <= 80)
        {
            _move++;
            return;
        }
        if(_move <= 81)
        {
            FocusFlowerBullet();
            _move++;
            return;
        }
        if(_move <= 82)
        {
            _move++;
            return;
        }
        if (_move <= 83)
        {
            FocusFlowerBullet();
            _move++;
            return;
        }
        if (_move <= 84)
        {
            _move++;
            return;
        }
        if (_move <= 85)
        {
            FocusFlowerBullet();
            _move++;
            return;
        }
        if (_move <= 86)
        {
            _move++;
            return;
        }
        if (_move <= 87)
        {
            FocusFlowerBullet();
            _move++;
            return;
        }
        if (_move <= 88)
        {
            _move++;
            return;
        }
        if(_move <= 104)
        {
            FocusFlowerBullet();
            FocusBullet();
            _move++;
            return;
        }
        if(_move <= 120)
        {
            Turn();
            _move++;
            return;
        }
        if(_move <= 136)
        {
            FSMix();
            _move++;
            return;
        }
        if(_move <= 160)
        {
            FSMixFlower();
            _move++;
            return;
        }
        if(_move <= 164)
        {
            FSMix();
            _move++;
            return;
        }
        if(_move <= 168)
        {
            _move++;
            return;
        }
        if(_move <= 184)
        {
            SixBullet();
            _move++;
            return;
        }
        if(_move <= 185)
        {
            SixBullet();
            FocusFlowerBullet();
            _move++;
            return;
        }
        if(_move <= 186)
        {
            SixBullet();
            _move++;
            return;
        }
        if (_move <= 187)
        {
            SixBullet();
            FocusFlowerBullet();
            _move++;
            return;
        }
        if (_move <= 188)
        {
            SixBullet();
            _move++;
            return;
        }
        if (_move <= 189)
        {
            SixBullet();
            FocusFlowerBullet();
            _move++;
            return;
        }
        if (_move <= 190)
        {
            SixBullet();
            _move++;
            return;
        }
        if (_move <= 191)
        {
            SixBullet();
            FocusFlowerBullet();
            _move++;
            return;
        }
        if (_move <= 192)
        {
            SixBullet();
            _move++;
            return;
        }
        if (_move <= 193)
        {
            SixBullet();
            FocusFlowerBullet();
            _move++;
            return;
        }
        if (_move <= 194)
        {
            SixBullet();
            _move++;
            return;
        }
        if (_move <= 195)
        {
            SixBullet();
            FocusFlowerBullet();
            _move++;
            return;
        }
        if (_move <= 196)
        {
            SixBullet();
            _move++;
            return;
        }
        if (_move <= 197)
        {
            SixBullet();
            FocusFlowerBullet();
            _move++;
            return;
        }
        if (_move <= 198)
        {
            SixBullet();
            _move++;
            return;
        }
        if (_move <= 199)
        {
            SixBullet();
            FocusFlowerBullet();
            _move++;
            return;
        }
        if (_move <= 200)
        {
            SixBullet();
            _move++;
            return;
        }
        if (_move <= 201)
        {
            SixBullet();
            FocusFlowerBullet();
            _move++;
            return;
        }
        if (_move <= 202)
        {
            SixBullet();
            _move++;
            return;
        }
        if (_move <= 203)
        {
            SixBullet();
            FocusFlowerBullet();
            _move++;
            return;
        }
        if (_move <= 204)
        {
            SixBullet();
            _move++;
            return;
        }
        if (_move <= 205)
        {
            SixBullet();
            FocusFlowerBullet();
            _move++;
            return;
        }
        if (_move <= 206)
        {
            SixBullet();
            _move++;
            return;
        }
        if (_move <= 207)
        {
            SixBullet();
            FocusFlowerBullet();
            _move++;
            return;
        }
        if (_move <= 208)
        {
            SixBullet();
            _move++;
            return;
        }
        if(_move <= 212)
        {
            _move++;
            return;
        }
        if(_move <= 213)
        {
            SixFlower();
            _move++;
            return;
        }
        if(_move <= 216)
        {
            _move++;
            return;
        }
        if(_move <= 232)
        {
            FSMixFlower();
            _move++;
            return;
        }
        if(_move <= 244)
        {
            FSMix();
            _move++;
            return;
        }
        if(_move <= 248)
        {
            SixFlower();
            _move++;
            return;
        }
        if(_move <= 249)
        {
            SixBullet();
            FocusFlowerBullet();
            _move++;
            return;
        }
        if(_move <= 250)
        {
            SixBullet();
            _move++;
            return;
        }
        if (_move <= 251)
        {
            SixBullet();
            FocusFlowerBullet();
            _move++;
            return;
        }
        if (_move <= 252)
        {
            SixBullet();
            _move++;
            return;
        }
        if (_move <= 253)
        {
            SixBullet();
            FocusFlowerBullet();
            _move++;
            return;
        }
        if (_move <= 254)
        {
            SixBullet();
            _move++;
            return;
        }
        if (_move <= 255)
        {
            SixBullet();
            FocusFlowerBullet();
            _move++;
            return;
        }
        if (_move <= 256)
        {
            SixBullet();
            _move++;
            return;
        }
        if (_move <= 257)
        {
            SixBullet();
            FocusFlowerBullet();
            _move++;
            return;
        }
        if (_move <= 258)
        {
            SixBullet();
            _move++;
            return;
        }
        if (_move <= 259)
        {
            SixBullet();
            FocusFlowerBullet();
            _move++;
            return;
        }
        if (_move <= 260)
        {
            SixBullet();
            _move++;
            return;
        }
        if (_move <= 261)
        {
            SixBullet();
            FocusFlowerBullet();
            _move++;
            return;
        }
        if (_move <= 262)
        {
            SixBullet();
            _move++;
            return;
        }
        if (_move <= 263)
        {
            SixBullet();
            FocusFlowerBullet();
            _move++;
            return;
        }
        if (_move <= 264)
        {
            SixBullet();
            _move++;
            return;
        }
        if (_move <= 265)
        {
            SixBullet();
            FocusFlowerBullet();
            _move++;
            return;
        }
        if (_move <= 266)
        {
            SixBullet();
            _move++;
            return;
        }
        if (_move <= 267)
        {
            SixBullet();
            FocusFlowerBullet();
            _move++;
            return;
        }
        if (_move <= 268)
        {
            SixBullet();
            _move++;
            return;
        }
        if (_move <= 269)
        {
            SixBullet();
            FocusFlowerBullet();
            _move++;
            return;
        }
        if (_move <= 270)
        {
            SixBullet();
            _move++;
            return;
        }
        if (_move <= 271)
        {
            SixBullet();
            FocusFlowerBullet();
            _move++;
            return;
        }
        if (_move <= 272)
        {
            SixBullet();
            _move++;
            return;
        }
        if (_move <= 273)
        {
            SixBullet();
            FocusFlowerBullet();
            _move++;
            return;
        }
        if (_move <= 274)
        {
            SixBullet();
            _move++;
            return;
        }
         if (_move <= 275)
        {
            SixBullet();
            FocusFlowerBullet();
            _move++;
            return;
        }
        if (_move <= 276)
        {
            SixBullet();
            _move++;
            return;
        }
        if (_move <= 277)
        {
            SixBullet();
            FocusFlowerBullet();
            _move++;
            return;
        }
        if (_move <= 278)
        {
            SixBullet();
            _move++;
            return;
        }
        if (_move <= 294)
        {
            SixBullet();
            FocusFlowerBullet();
            _move++;
            return;
        }
        if(_move <= 302)
        {
            FocusBullet();
            FiveBullet();
            _move++;
            if(_move == 302)
            {
                _move = 0;
            }
            return;
        }
    }
}
