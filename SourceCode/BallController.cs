using UnityEngine;

public class BallController : MonoBehaviour
{
    public static BallController instance;
    [SerializeField] private Transform _ballPos;

    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BallReset()
    {
        this.transform.position = _ballPos.position;
    }
}
