using UnityEngine;

public class BallCount : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ball"))
        {
            ScoreManager.instance.CountBall();
        }
    }
}
