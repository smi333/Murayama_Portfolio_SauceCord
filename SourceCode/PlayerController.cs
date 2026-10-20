using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _Force = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            collision.rigidbody.AddForce(new Vector3(0f, 1f, 0f) * _Force);
            collision.rigidbody.AddForce(-(transform.position - collision.transform.position) * _Force);
        }
    }

}
