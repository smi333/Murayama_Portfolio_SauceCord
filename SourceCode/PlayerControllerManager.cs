using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerManager : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }
    private void OnEnable()
    {
        if (_playerInput == null) return;
        _playerInput.onActionTriggered += NoteJudge;
    }
    private void OnDisable()
    {
        if (_playerInput == null) return;
        _playerInput.onActionTriggered -= NoteJudge;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void NoteJudge(InputAction.CallbackContext context)
    {
        if (context.action.name != "Catch") return;
        if (!context.performed) return;
        if (BallSpawn.Instance._noteNum.Count <= 0) return;
        Debug.Log("押した");
        if (BallSpawn.Instance._noteNum[0] == 0)
        {
            BallMove.Instance.Judge();
        }
        else if (BallSpawn.Instance._noteNum[0] == 1)
        {
            TwoBallMove.Instance.Judge();
        }
    }
}
