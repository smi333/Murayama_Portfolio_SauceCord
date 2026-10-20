using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class FieldController : MonoBehaviour
{
    private PlayerInput _playerInput;
    [SerializeField] private Rigidbody _playerRb;
    [SerializeField] private Rigidbody _EnemyRb;
    [SerializeField] private Transform _AnchorPos;
    [SerializeField] private float _force = 5f;

    [SerializeField] private Transform _playerPos;
    [SerializeField] private Transform _EnemyPos;
    private bool _isPlay = true;
    PlayerManager.Judge_TYPE _type;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _isPlay = true;
    }

    private void Update()
    {
        //回転角度を取得
        Vector3 playerEuler = _playerPos.transform.rotation.eulerAngles;
        Vector3 enemyEuler = _EnemyPos.transform.rotation.eulerAngles;
       
        if (-70 >= playerEuler.x && playerEuler.x >= -90 || 70 <= playerEuler.x && playerEuler.x <= 90 
            || -70 >= playerEuler.z && playerEuler.z >= -90 || 70 <= playerEuler.z && playerEuler.z <= 90)
        {
            if (_isPlay == false) return;
            _type = PlayerManager.Judge_TYPE.LOSE;
            PlayerManager.Instance.Judge(_type);
            _isPlay = false;
        }
        if (-70 >= enemyEuler.x && enemyEuler.x >= -90 || 70 <= enemyEuler.x && enemyEuler.x <= 90
            || -70 >= enemyEuler.z && enemyEuler.z >= -90 || 70 <= enemyEuler.z && enemyEuler.z <= 90)
        {
            if (_isPlay == false) return;
            _type = PlayerManager.Judge_TYPE.WIN;
            PlayerManager.Instance.Judge(_type);
            _isPlay = false;
        }
    }


    private void OnEnable()
    {
        if (_playerInput == null) return;
        _playerInput.onActionTriggered += Onattack;
        _playerInput.onActionTriggered += OnMove;
    }

    private void OnDisable()
    {
        if (_playerInput == null) return;
        _playerInput.onActionTriggered -= Onattack;
        _playerInput.onActionTriggered -= OnMove;
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            _type = PlayerManager.Judge_TYPE.LOSE;
            PlayerManager.Instance.Judge(_type);
            Debug.Log("あなたの負け");
        }
        if (collision.collider.CompareTag("Enemy"))
        {
            _type = PlayerManager.Judge_TYPE.WIN;
            PlayerManager.Instance.Judge(_type);
            Debug.Log("あなたの勝ち");
        }
    }

    private void Onattack(InputAction.CallbackContext context)
    {
        Debug.Log("押した");
        if (context.action.name != "BoxAttack") return;
        if (_playerRb == null) return;
        Vector3 direction = _AnchorPos.position - transform.position;
        direction.y = 0f;
        _playerRb.AddForce(-direction * _force);
        _playerRb.AddForce(new Vector3(0f,1f,0f) * 10f);
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        if (context.action.name != "Move") return;
        Vector2 axis = context.ReadValue<Vector2>();
        Debug.Log(axis);
        float movex = axis.x * 3f;
        float movez = axis.y * 3f;
        Vector3 newPosition = new Vector3(movex, 1, movez);
        _AnchorPos.transform.position = newPosition;
    }
}
