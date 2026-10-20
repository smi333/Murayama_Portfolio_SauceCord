using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    private float _rimitX = 9f;
    private float _rimitY = 5f;
    private PlayerInput _playerInput;
    private Vector3 _velocity;
    [SerializeField]private float _speed;
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

    // Update is called once per frame
    void Update()
    {
        transform.position += _velocity * _speed * Time.deltaTime;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        if (context.action.name != "Move") return;
        var axis = context.ReadValue<Vector2>();
        _velocity = new Vector3(axis.x, axis.y, 0);

        Vector3 crrentPos = transform.position;
        crrentPos.x = Mathf.Clamp(crrentPos.x, -_rimitX, _rimitX);
        crrentPos.y = Mathf.Clamp(crrentPos.y, -_rimitY, _rimitY);
        transform.position = crrentPos;
        

    }
}
