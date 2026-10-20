using UnityEngine;
using UnityEngine.Windows;
public class Plunger : MonoBehaviour
{
    private bool _ballSet = false;
    private float maxFarce = 500f; //最大発射力
    private float chargeRate = 250f; //1秒間にたまる力
    [SerializeField]private float currentForce = 0f;
    public KeyCode launchKey = KeyCode.Space;

    public Rigidbody ballRb; //射出するボールのRigidbody

    // Update is called once per frame
    void Update()
    {
        //キーを押している間パワーをためる
        if(UnityEngine.Input.GetKey(launchKey) && _ballSet == true)
        {
            currentForce = Mathf.Min(currentForce + chargeRate * Time.deltaTime, maxFarce);
        }
        //キーを離した瞬間に発射
        if(UnityEngine.Input.GetKeyUp(launchKey))
        {
            ballRb.AddForce(Vector3.forward * currentForce);
            currentForce = 0f;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        _ballSet = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        _ballSet = false;
    }
}
