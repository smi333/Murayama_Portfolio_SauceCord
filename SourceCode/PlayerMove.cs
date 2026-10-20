using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;
    private PlayerInput _playerInput;
    private Vector3 _velocity;
    private float _speed = 5;
    private float _xLimit = 8.6f;
    private float _yLimit = 4.9f;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }
    private void OnEnable()
    {
        if (_playerInput == null) return;
        _playerInput.onActionTriggered += OnMove;
    }
    private void OnDisable()
    {
        if (_playerInput == null) return;
        _playerInput.onActionTriggered -= OnMove;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    
    private void OnMove(InputAction.CallbackContext context)
    {
        if (context.action.name != "Move") return;
        var axis = context.ReadValue<Vector2>();
        _velocity = new Vector3(axis.x, axis.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        _speed = _playerData.Speed;
        transform.position += _velocity *_speed *  Time.deltaTime;
        Vector3 currentPos = transform.position;
        currentPos.x = Mathf.Clamp(currentPos.x, -_xLimit, _xLimit);
        currentPos.y = Mathf.Clamp(currentPos.y, -_yLimit, _yLimit);
        transform.position = currentPos;
    }
}
