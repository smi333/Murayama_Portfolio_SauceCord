using UnityEngine;

public class Exp : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _rotateSpeed = 200f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _target = GameObject
            .FindGameObjectWithTag("Player")
            .GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        if (_target == null) return;
        Vector3 direction = (_target.position - transform.position).normalized;
        direction.z = 0f;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        lookRotation.x = 0f;
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, _rotateSpeed * Time.deltaTime);
        transform.position += direction * _speed * Time.deltaTime;
    }
}
