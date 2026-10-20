using UnityEngine;

public class Wall : MonoBehaviour
{
    private Rigidbody2D _rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("接触");
        if(collision.gameObject.CompareTag("Ball"))
        {
            Destroy(collision.gameObject);
        }
    }
}
