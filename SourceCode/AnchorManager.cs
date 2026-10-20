using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class AnchorManager : MonoBehaviour
{
    private PlayerInput _playerInput;
    
    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        if(_playerInput == null) return;
        _playerInput.onActionTriggered += OnMove;
    }

    private void OnDisable()
    {
        if(_playerInput == null) return;
        _playerInput.onActionTriggered -= OnMove;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMove(InputAction.CallbackContext context)
    {
        
        if (context.action.name != "Move") return;
        Vector2 axis = context.ReadValue<Vector2>();
        Debug.Log(axis);
        float movex = axis.x * 3f;
        float movez = axis.y * 3f;
        Vector3 newPosition = new Vector3(movex, 1, movez);
        this.transform.position = newPosition;
    }

}
