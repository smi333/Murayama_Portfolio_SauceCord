using UnityEngine;

public class Bumper : MonoBehaviour
{
    private float force = 3f;
    [SerializeField]private int _addScore;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 direction = collision.transform.position - this.transform.position;
                direction.y = 0;

                rb.AddForce(direction.normalized * force, ForceMode.Impulse);

                ScoreManager.instance.AddScore(_addScore);
            }
        }
    }
}
